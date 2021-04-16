using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace mEXTRADROPSedit.Core
{
    /// <summary>
    /// Represents entire extra drops table. The first 4 bytes seem to denote the version number, but this is still 
    /// unverified. The next 4 bytes seems to denote the number of ExtraDropEntry the file contains. After that follows 
    /// the ExtraDropSpecial, and followed by a number of ExtraDropEntry.
    /// </summary>
    public class ExtraDropTable
    {
        public int Version { get; set; }

        public List<ExtraDropEntry> Entries { get; } = new List<ExtraDropEntry>();

        public ExtraDropTable()
        {
            Version = 1;
        }

        /// <summary>
        /// Adds a new blank entry to the list of entries and returns it.
        /// </summary>
        /// <returns>A blank entry.</returns>
        public ExtraDropEntry NewEntry()
        {
            ExtraDropEntry entry = new ExtraDropEntry();
            Entries.Add(entry);

            return entry;
        }

        /// <summary>
        /// Clones an existing entry and add it to the list of entries and returns it.
        /// </summary>
        /// <param name="index">The index of the entry to clone.</param>
        /// <returns>The cloned entry.</returns>
        public ExtraDropEntry CloneEntry(int index)
        {
            ExtraDropEntry entry = new ExtraDropEntry(Entries[index]);
            Entries.Add(entry);

            return entry;
        }

        /// <summary>
        /// Deletes the entry at the given index.
        /// </summary>
        /// <param name="index">The index of the entry to delete.</param>
        public void DeleteEntry(int index)
        {
            Entries.RemoveAt(index);
        }

        /// <summary>
        /// Search for an entry that contains either a monster or an item with the given id, returns the index, or -1
        /// if such an entry does not exist. Optionally include an offsets to begin the search at.
        /// </summary>
        /// <param name="id">The id to search for.</param>
        /// <param name="entryOffset">Only search entries with index >= this offset.</param>
        /// <param name="monsterOffset">Only search monsters with index >= this offset.</param>
        /// <param name="itemOffset">Only search items with index >= this offset.</param>
        /// <returns>A tuple containing first the index of the entry, then the index of the monster, then the index of
        /// the item, or -1 if it doesn't exist.</returns>
        public Tuple<int, int, int> FindEntry(long id, int entryOffset, int monsterOffset, int itemOffset)
        {
            List<ExtraDropEntry> offsetEntries = Entries.Skip(entryOffset).ToList();

            for (int i = 0; i < offsetEntries.Count; ++i)
            {
                ExtraDropEntry entry = offsetEntries[i];

                // The problem here is that item ids are uint while monster ids are regular int. So we instead read it
                // as a long to be able to store both values and then cast it to either an int or uint. We can simply
                // discard the most significant bits since they really shouldn't have been specified anyway.
                int monsterIndex = entry.FindMonster(unchecked((int) id), monsterOffset);
                int itemIndex = entry.FindItem(unchecked((uint) id), itemOffset);

                if (monsterIndex > -1 || itemIndex > -1)
                {
                    return Tuple.Create(i + entryOffset, monsterIndex, itemIndex);
                }

                // It only makes sense to check the offset the first time because we're still in the same entry. 
                // However, when we move to the next entry, it makes sense to set it to 0.
                monsterOffset = 0;
                itemOffset = 0;
            }

            return Tuple.Create(-1, -1, -1);
        }

        /// <summary>
        /// Save the extra drops table to a file given by the output stream.
        /// </summary>
        /// <param name="output">An output stream to a file that can be writen to.</param>
        public void Serialize(Stream output)
        {
            BinaryWriter writer = new BinaryWriter(output);

            // Version number comes first.
            writer.Write(Version);

            // Next is the number of ExtraDropEntry in the table.
            writer.Write(Entries.Count);

            // Write all the entries.
            foreach (ExtraDropEntry entry in Entries)
            {
                entry.Serialize(output);
            }
        }

        /// <summary>
        /// Construct the extra drops table by deserializing from a stream.
        /// </summary>
        /// <param name="input">The input stream to deserialize from.</param>
        public ExtraDropTable(Stream input)
        {
            BinaryReader reader = new BinaryReader(input);
            
            // The first 4 bytes is believed to be the version number, although this isn't 100% confirmed. We will only
            // support version 1 for now, because other versions may have unknown structure.
            int version = reader.ReadInt32();
            if (version != 1)
            {
                throw new System.NotSupportedException(version.ToString());
            }
            Version = version;

            // The number of ExtraDropEntry that exists in this table.
            int numEntries = reader.ReadInt32();
            Entries.Capacity = numEntries;

            for (int i = 0; i < numEntries; ++i)
            {
                ExtraDropEntry entry = new ExtraDropEntry(input);
                Entries.Add(entry);
            }
        }
    }
}

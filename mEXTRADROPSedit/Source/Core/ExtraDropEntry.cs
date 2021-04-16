using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mEXTRADROPSedit.Core
{
     /// <summary>
     /// According to the EXTRADROPTABLE.h struct that Teemo Cell extracted, every entry can either be of type 
     /// EDT_TYPE_REPLACE or EDT_TYPE_ADDON. As to what these values represent is still unknown. My best guess is that 
     /// REPLACE would replace the regular drop table with the extra drop table, while ADDON allows both the regular drop 
     /// table and the extra drop table to exist. 
     /// </summary>
    public enum ExtraDropType
    {
        Replace = 1,
        Addon = 2,
    };

    public class ExtraDropEntry
    {
        public string Name { get; private set; }

        public ExtraDropType Type { get; private set; }

        private readonly float[] _dropNumProbabilities = new float[8];

        public List<int> Monsters { get; } = new List<int>();

        public List<ExtraDropItem> DropItems { get; } = new List<ExtraDropItem>(256);

        public ExtraDropEntry()
        {
            Type = ExtraDropType.Addon;
            Name = "< new >";
        }

        /// <summary>
        /// Constructs a new entry by cloning an existing entry.
        /// </summary>
        /// <param name="entry">The entry to clone.</param>
        public ExtraDropEntry(ExtraDropEntry entry)
        {
            Name = entry.Name;
            Type = entry.Type;
            
            // There are always 8 probabilities based on the EXTRADROPTABLE.h struct that Teemo Cell extracted from the 
            // gs.
            for (int i = 0; i < 8; ++i)
            {
                _dropNumProbabilities[i] = entry._dropNumProbabilities[i];
            }

            foreach (int monsterId in entry.Monsters)
            {
                Monsters.Add(monsterId);
            }

            foreach (ExtraDropItem item in entry.DropItems)
            {
                DropItems.Add(new ExtraDropItem(item));
            }
        }

        /// <summary>
        /// Treats an array of bytes as a GB18030 encoded string and set it as the entry's name. A maximum of 128 bytes
        /// are allowed.
        /// </summary>
        /// <param name="name">An array to be treated as a GB18030 encoded string.</param>
        public void SetName(byte[] name)
        {
            if (name.Length > 128)
            {
                // First 128 bytes.
                IEnumerable<byte> slice = name.Take(128);
                name = slice.ToArray();
            }

            Name = Encoding.GetEncoding("GB18030").GetString(name);
        }

        /// <summary>
        /// Sets the entry's name. A maximum of 128 bytes are allowed.
        /// </summary>
        /// <param name="name">The new name.</param>
        public void SetName(string name)
        {
            byte[] bytes = Encoding.GetEncoding("GB18030").GetBytes(name);
            if (bytes.Length > 128)
            {
                // First 128 bytes.
                IEnumerable<byte> slice = bytes.Take(128);
                name = Encoding.GetEncoding("GB18030").GetString(slice.ToArray());
            }

            Name = name;
        }

        public void SetType(int type)
        {
            if (type != 1 && type != 2)
            {
                throw new InvalidCastException(type.ToString());
            }

            Type = (ExtraDropType) type;
        }

        public void SetType(ExtraDropType type)
        {
            Type = type;
        }

        /// <summary>
        /// Returns the probability of dropping i items.
        /// </summary>
        /// <param name="i">The number of items to drop.</param>
        /// <returns>The probability of dropping i items.</returns>
        public float GetDropProbability(int i)
        {
            return _dropNumProbabilities[i];
        }

        /// <summary>
        /// Sets the probability to drop i items.
        /// </summary>
        /// <param name="i">The number of items to drop.</param>
        /// <param name="probability">The probability of dropping i items.</param>
        public void SetDropProbability(int i, float probability)
        {
            _dropNumProbabilities[i] = probability;
        }

        /// <summary>
        /// Adds a new monster with an id of 0, and returns the added id.
        /// </summary>
        /// <returns>The added id of the new monster, which is 0.</returns>
        public int NewMonster()
        {
            Monsters.Add(0);
            return 0;
        }

        /// <summary>
        /// Edits an existing monster to have a new id.
        /// </summary>
        /// <param name="index">The index of the existing monster.</param>
        /// <param name="monsterId">The new monster id.</param>
        public void EditMonster(int index, int monsterId)
        {
            Monsters[index] = monsterId;
        }

        /// <summary>
        /// Deletes a monster at the given index,
        /// </summary>
        /// <param name="index">The index of the monster to delete.</param>
        public void DeleteMonster(int index)
        {
            Monsters.RemoveAt(index);
        }

        /// <summary>
        /// Adds a drop item to the entry and returns it.
        /// </summary>
        /// <param name="id">The id of the item to drop.</param>
        /// <param name="probability">The probability of dropping the item.</param>
        /// <returns>The added item.</returns>
        public ExtraDropItem AddItem(uint id, float probability)
        {
            // Based on the EXTRADROPTABLE.h struct that Teemo Cell extracted, there can only be 256 items.
            if (DropItems.Count >= 256)
            {
                throw new System.OverflowException("Too many items in entry");
            }

            ExtraDropItem item = new ExtraDropItem(id, probability);
            DropItems.Add(item);

            return item;
        }

        /// <summary>
        /// Adds a new item with id of 0 and probability of 0 and returns it.
        /// </summary>
        /// <returns>The new item with id of 0 and probability of 0.</returns>
        public ExtraDropItem NewItem()
        {
            return AddItem(0, 0.0f);
        }

        /// <summary>
        /// Edits only the id of the item at the given index.
        /// </summary>
        /// <param name="index">Index of the item to edit.</param>
        /// <param name="id">The item's new id.</param>
        public void EditItemId(int index, uint id)
        {
            DropItems[index].Id = id;
        }

        /// <summary>
        /// Edits only the probability of the item at the given index.
        /// </summary>
        /// <param name="index">The index of the item to edit.</param>
        /// <param name="probability">The item's new probability</param>
        public void EditItemProbability(int index, float probability)
        {
            DropItems[index].Probability = probability;
        }

        /// <summary>
        /// Deletes a drop item from the entry at the given index.
        /// </summary>
        /// <param name="index">The index of the item to delete.</param>
        public void DeleteItem(int index)
        {
            DropItems.RemoveAt(index);
        }

        /// <summary>
        /// Returns the sum of the 8 drop num probabilities.
        /// </summary>
        /// <returns>The sum of the 8 drop num probabilities.</returns>
        private float sumDropNumProbabilities()
        {
            float totalProbability = 0.0f;

            // There must always be exactly 8 probabilities, according to the EXTRADROPTABLE.h struct that Teemo Cell 
            // extracted from the gs.
            for (int i = 0; i < 8; ++i)
            {
                totalProbability += _dropNumProbabilities[i];
            }

            return totalProbability;
        }

        /// <summary>
        /// Fix the drop num probabilities so that they would add up to 1.0.
        /// </summary>
        public void FixDropNumProbabilities()
        {
            float totalProbability = sumDropNumProbabilities();

            // If all the probabilities are 0, we will simply set all of them to be 1 to prevent a division by 0 
            // scenario from occuring.
            if (totalProbability == 0.0f)
            {
                for (int i = 0; i < 8; ++i)
                {
                    _dropNumProbabilities[i] = 1.0f;
                    totalProbability = totalProbability + 1.0f;
                }
            }
            
            // There must always be exactly 8 probabilities, according to the EXTRADROPTABLE.h struct that Teemo Cell 
            // extracted from the gs.
            for (int i = 0; i < 8; ++i)
            {
                _dropNumProbabilities[i] = _dropNumProbabilities[i] / totalProbability;
            }
            
        }

        /// <summary>
        /// Checks whether or not the drop num probabilities add up to 1.
        /// </summary>
        /// <returns>Whether or not the drop num probabilities add up to 1.</returns>
        public bool IsDropNumProbabilitiesCorrect()
        {
            // This precision was chosen because it is the precision used by PWE.
            return Math.Abs(sumDropNumProbabilities() - 1.0f) <= 0.0000009;
        }

        /// <summary>
        /// Returns the sum of the probabilities of all the drop items added together.
        /// </summary>
        /// <returns>The sum of the probabilities of all the drop items added together.</returns>
        private float sumDropItemsProbabilities()
        {
            float totalProbability = 0.0f;

            foreach (ExtraDropItem item in DropItems)
            {
                totalProbability += item.Probability;
            }

            return totalProbability;;
        }

        /// <summary>
        /// Fix the probabilities of all the drop items so that they would add up to 1.0 together.
        /// </summary>
        public void FixDropItemsProbabilities()
        {
            float totalProbability = sumDropItemsProbabilities();

            // If all the probabilities are 0, we will simply set all of them to be 1 to prevent a division by 0 
            // scenario from occuring.
            if (totalProbability == 0.0f)
            {
                foreach (ExtraDropItem item in DropItems)
                {
                    item.Probability = 1.0f;
                    totalProbability = totalProbability + 1.0f;
                }
            }

            foreach (ExtraDropItem item in DropItems)
            {
                item.Probability = item.Probability / totalProbability;
            }
        }

        /// <summary>
        /// Checks whether or not the probability of all the drop items together add up to 1.
        /// </summary>
        /// <returns>Whether or not the probability of all the drop items together add up to 1</returns>
        public bool IsDropItemsProbabilitiesCorrect()
        {
            // This precision was chosen because it is the precision used by PWE.
            return Math.Abs(sumDropItemsProbabilities() - 1.0f) <= 0.0000009;
        }

        /// <summary>
        /// Returns the index of the monster with the given monster id. If such a monster does not exist, -1 is 
        /// returned. Includes an offsets to begin the search at.
        /// </summary>
        /// <param name="monsterId">The monster id to search for.</param>
        /// <param name="offset">Only search monsters with index >= this offset.</param>
        /// <returns>Index of the monster with an id of monsterId or -1 if such a monster does not exist.</returns>
        public int FindMonster(int monsterId, int offset)
        {
            List<int> offsetMonsters = Monsters.Skip(offset).ToList();
            int index = offsetMonsters.IndexOf(monsterId);

            if (index == -1)
            {
                return -1;
            }
            
            return index + offset;
        }

        /// <summary>
        /// Returns the index of the item with the given item id. If such an item does not exist, -1 is returned. 
        /// Includes an offsets to begin the search at.
        /// </summary>
        /// <param name="itemId">The item id to search for.</param>
        /// <param name="offset">Only search items with index >= this offset.</param>
        /// <returns>Index of the item with an id of itemId or -1 if such an item does not exist.</returns>
        public int FindItem(uint itemId, int offset)
        {
            // Since Items are considered equivalent if the Id matches, we will create a template item with only the id.
            ExtraDropItem search = new ExtraDropItem(itemId, 0.0f);

            List<ExtraDropItem> offsetItems = DropItems.Skip(offset).ToList();
            int index = offsetItems.IndexOf(search);

            if (index == -1)
            {
                return -1;
            }

            return index + offset;
        }

        /// <summary>
        /// Overrides the ToString method to return only the Name. This is useful for displaying in ListBoxes.
        /// </summary>
        /// <returns>The Name of the entry.</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Serialize to an output stream.
        /// </summary>
        /// <param name="output">The output stream to serialize to.</param>
        public void Serialize(Stream output)
        {
            BinaryWriter writer = new BinaryWriter(output);

            // Serialize monsters.
            writer.Write(Monsters.Count);
            for (int i = 0; i < Monsters.Count; ++i)
            {
                writer.Write(Monsters[i]);
            }

            // Serialize items. There must always be exactly 256 items according to the EXTRADROPTABLE.h struct that 
            // Teemo Cell extracted from the gs, so we'll pad it with 0s to 256 items if there are less than 256 items.
            for (int i = 0; i < 256; ++i)
            {
                if (i < DropItems.Count)
                {
                    ExtraDropItem item = DropItems[i];
                    item.Serialize(output);
                }
                else
                {
                    // Pad with 0s.
                    ExtraDropItem padding = new ExtraDropItem(0, 0.0f);
                    padding.Serialize(output);
                }
            }

            // Serialize name by first converting it to bytes, so the encoding will be correct. We must also pad it up
            // to 128 bytes if it isn't already.
            byte[] nameBytes = Encoding.GetEncoding("GB18030").GetBytes(Name);
            byte[] namePadded = new byte[128];
            Array.Copy(nameBytes, namePadded, Math.Min(nameBytes.Length, 128));
            writer.Write(namePadded);
            
            // Serialize the type as an integer.
            writer.Write((int) Type);

            // Serialize the drop probabilities. There must always be exactly 8 probabilities, according to the 
            // EXTRADROPTABLE.h struct that Teemo Cell extracted from the gs.
            for (int i = 0; i < 8; ++i)
            {
                writer.Write(_dropNumProbabilities[i]);
            }
        }

        /// <summary>
        /// Construct the entry by deserializing from a stream.
        /// </summary>
        /// <param name="input">The input stream to deserialize from.</param>
        public ExtraDropEntry(Stream input)
        {
            BinaryReader reader = new BinaryReader(input);

            // Deserialize monsters.
            int numMonsters = reader.ReadInt32();
            for (int i = 0; i < numMonsters; ++i)
            {
                int monsterId = reader.ReadInt32();
                Monsters.Add(monsterId);
            }

            // Deserialize items. There must always be exactly 256 items based on the EXTRADROPTABLE.h struct that 
            // Teemo Cell extracted from the gs.
            for (int i = 0; i < 256; ++i)
            {
                ExtraDropItem item = new ExtraDropItem(input);

                // We'll only populate if the item id is non-zero, because an item id of zero actually represents no
                // item. This makes it easier for us to add or remove items later. We simply pad up to 256 items 
                // when we save.
                if (item.Id > 0)
                {
                    DropItems.Add(item);
                }
            }

            // Deserialize name. This is always 128 bytes based on the EXTRADROPTABLE.h struct that Teemo Cell extracted
            // from the gs.
            byte[] nameBytes = reader.ReadBytes(128);
            SetName(nameBytes);

            // Deserialize type.
            int type = reader.ReadInt32();
            SetType(type);

            // Deserialize the drop num probabilities. There are always 8 probabilities based on the EXTRADROPTABLE.h 
            // struct that Teemo Cell extracted from the gs.
            for (int i = 0; i < 8; ++i)
            {
                float probability = reader.ReadSingle();
                _dropNumProbabilities[i] = probability;
            }
        }
    }
}

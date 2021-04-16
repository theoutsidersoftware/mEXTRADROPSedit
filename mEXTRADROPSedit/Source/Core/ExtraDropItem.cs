using System;
using System.Globalization;
using System.IO;

namespace mEXTRADROPSedit.Core
{
    public class ExtraDropItem
    {
        // The Id is unsigned according to the EXTRADROPTABLE.h struct that Teemo Cell extracted from the gs.
        public uint Id { get; set; }
        public float Probability { get; set; }

        public ExtraDropItem(uint id, float probability)
        {
            Id = id;
            Probability = probability;
        }

        /// <summary>
        /// Constructs a new item by cloning an existing item.
        /// </summary>
        /// <param name="item">The item to clone.</param>
        public ExtraDropItem(ExtraDropItem item)
        {
            Id = item.Id;
            Probability = item.Probability;
        }

        /// <summary>
        /// Overrides the ToString method to for displaying in ListBoxes.
        /// </summary>
        /// <returns>Formatted string of the Id and Probability of the item.</returns>
        public override string ToString()
        {
            return string.Format("{0} ({1})", Id, Probability.ToString("0.0###############"));
        }

        /// <summary>
        /// Overrides equality operators to compare by Id.
        /// </summary>
        public override bool Equals(Object obj)
        {
            if (!(obj is ExtraDropItem))
            {
                return false;
            }

            ExtraDropItem other = (ExtraDropItem)obj;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Probability.GetHashCode();
        }

        /// <summary>
        /// Overrides equality operators to compare by Id.
        /// </summary>
        public static bool operator ==(ExtraDropItem x, ExtraDropItem y)
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Id == y.Id;
        }

        /// <summary>
        /// Overrides equality operators to compare by Id.
        /// </summary>
        public static bool operator !=(ExtraDropItem x, ExtraDropItem y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Serialize to an output stream.
        /// </summary>
        /// <param name="output">The output stream to serialize to.</param>
        public void Serialize(Stream output)
        {
            BinaryWriter writer = new BinaryWriter(output);
            writer.Write(Id);
            writer.Write(Probability);
        }

        /// <summary>
        /// Deserialize the item from an input stream.
        /// </summary>
        /// <param name="input">The input stream to deserialize from.</param>
        public ExtraDropItem(Stream input)
        {
            BinaryReader reader = new BinaryReader(input);

            Id = reader.ReadUInt32();
            Probability = reader.ReadSingle();
        }
    }
}

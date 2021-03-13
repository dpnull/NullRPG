using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface ISlot
    {
        public int ObjectId { get; set; }
        public List<IItem> Item { get; set; }
    }
}
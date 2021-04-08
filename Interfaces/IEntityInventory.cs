using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface IEntityInventory
    {
        int ObjectId { get; set; }
        public Dictionary<int, ISlot> Slots { get; set; }

        public IItem WeaponSlot { get; set; }
        public IItem HeadSlot { get; set; }
        public IItem ChestSlot { get; set; }
        public IItem LegsSlot { get; set; }
        public int GetUniqueSlotId();
    }
}
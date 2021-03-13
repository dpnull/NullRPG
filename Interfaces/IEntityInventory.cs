using NullRPG.ItemTypes;
using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface IEntityInventory
    {
        public Dictionary<int, ISlot> Slots { get; set; }

        public int GetUniqueSlotId();

        public WeaponItem CurrentWeapon { get; set; }
        public HeadItem CurrentHeadItem { get; set; }
        public BodyItem CurrentBodyItem { get; set; }
        public LegsItem CurrentLegsItem { get; set; }
    }
}
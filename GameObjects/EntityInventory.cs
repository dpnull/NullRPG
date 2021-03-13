using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using System.Collections.Generic;

namespace NullRPG.GameObjects
{
    public abstract class EntityInventory : IEntityInventory
    {
        public Dictionary<int, ISlot> Slots { get; set; }

        public WeaponItem CurrentWeapon { get; set; }
        public HeadItem CurrentHeadItem { get; set; }
        public BodyItem CurrentBodyItem { get; set; }
        public LegsItem CurrentLegsItem { get; set; }

        public EntityInventory()
        {
            Slots = new Dictionary<int, ISlot>();
        }

        private int _currentId;

        public int GetUniqueSlotId()
        {
            return _currentId++;
        }

        public string GetWeaponName()
        {
            return CurrentWeapon?.Name.ToString();
        }
    }
}
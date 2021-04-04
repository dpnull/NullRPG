using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{
    public static class Enums
    {
        public enum InventorySlotTypes
        {
            Weapon,
            Head,
            Chest,
            Legs
        }

        public enum ItemSubTypes
        {
            HeadArmor,
            ChestArmor,
            LegsArmor,
        }

        public enum ItemTypes
        {
            Weapon,
            Armor
        }

        public enum ArmorTypes
        {
            Head,
            Chest,
            Legs
        }

        public enum WeaponType
        {
            Default,
            Sword,
            Axe
        }
    }
}

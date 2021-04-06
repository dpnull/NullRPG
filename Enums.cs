﻿using System.ComponentModel;

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

        public enum ItemTypes
        {
            [Description("Head")]
            HeadArmor,
            [Description("Chest")]
            ChestArmor,
            [Description("Head")]
            LegsArmor,
            [Description("Sword")]
            Sword,
            [Description("Material")]
            Material,
            [Description("Misc")]
            Misc
        }

        // Uncertain whether this is necessary and can be replaced with something else
        public enum ItemCategories
        {
            Weapon,
            Armor,
            Misc
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
using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace NullRPG.ItemTypes
{
    [Description("[Weapon Item]")]
    public class WeaponItem : Item
    {
        public WeaponItem(string name, Item.RarityType rarity, int level, int gold, int minDmg, int maxDmg)
            : base(name, rarity, true, level, gold, minDmg, maxDmg)
        {

        }

        public static WeaponItem None()
        {
            return new WeaponItem("None", RarityType.Common, 0, 0, 0, 0);
        }

        public static WeaponItem Longsword()
        {
            return new WeaponItem("Longsword", RarityType.Uncommon, 1, 10, 7, 12);
        }

        public static WeaponItem Oliaxe()
        {
            return new WeaponItem("Oliaxe", RarityType.Legendary, 1, 10, 30, 45);
        }
    }
}

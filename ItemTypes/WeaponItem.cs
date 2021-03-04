using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace NullRPG.ItemTypes
{
    public class WeaponItem : Item
    {
        public WeaponItem(string name, int gold, RarityType rarity, int level, int minDmg, int maxDmg) : base(name, gold, rarity, level, minDmg, maxDmg, 0, true)
        {

        }

        public static WeaponItem None()
        {
            return new WeaponItem("None", 0, RarityType.Common, 1, 0, 0);
        }

        public static WeaponItem Longsword()
        {
            return new WeaponItem("Longsword", 20, RarityType.Uncommon, 1, 9, 15);
        }

        public static WeaponItem Axe()
        {
            return new WeaponItem("Axe", 20, RarityType.Common, 1, 10, 20);
        }
    }
}

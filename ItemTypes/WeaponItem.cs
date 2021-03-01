using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace NullRPG.ItemTypes
{
    public class WeaponItem : Item
    {
        public WeaponItem(string name, int gold, int level, int minDmg, int maxDmg) : base(name, gold, level, minDmg, maxDmg, 0, true)
        {

        }

        public static WeaponItem None()
        {
            return new WeaponItem("None", 0, 0, 0, 0);
        }

        public static WeaponItem Longsword()
        {
            return new WeaponItem("Longsword", 20, 1, 9, 15);
        }

        public static WeaponItem Axe()
        {
            return new WeaponItem("Axe", 20, 1, 10, 20);
        }
    }
}

using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class WeaponItem : Item
    {
        private WeaponItem(int id, string name, int gold, int level, int minDmg, int maxDmg, bool isUnique)
            : base(id, name, gold, level, minDmg, maxDmg)
        {

        }

        public static WeaponItem Barehanded()
        {
            return new WeaponItem(2000, "Barehanded", 0, 0, 0, 3, true);
        }

        public static WeaponItem Longsword()
        {
            return new WeaponItem(2001, "Longsword", 10, 1, 7, 10, true);
        }

        public static WeaponItem Broadsword()
        {
            return new WeaponItem(2001, "Broadsword", 10, 1, 8, 9, true);
        }
    }
}

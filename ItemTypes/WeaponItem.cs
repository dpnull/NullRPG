using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class WeaponItem : Item
    {
        private WeaponItem(int id, string name, string description, int gold, int level, int minDmg, int maxDmg, bool isUnique)
            : base(id, name, description, gold, level, minDmg, maxDmg)
        {

        }

        public static WeaponItem Barehanded()
        {
            return new WeaponItem(2000, "Barehanded", "Barehands better than a lack thereof", 0, 0, 0, 3, true);
        }

        public static WeaponItem Longsword()
        {
            return new WeaponItem(2001, "Longsword", "A remarkable solid weapon.", 10, 1, 7, 10, true);
        }

        public static WeaponItem Broadsword()
        {
            return new WeaponItem(2001, "Broadsword", "Longsword's shorter brother.", 10, 1, 8, 9, true);
        }
    }
}

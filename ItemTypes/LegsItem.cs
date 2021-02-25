using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class LegsItem : Item
    {
        private LegsItem(int id, string name, int gold, int level, int defense, int health, bool isUnique)
            : base(id, name, gold, isUnique, level, 0, 0, defense, health)
        {

        }

        public static LegsItem IronLeggings()
        {
            return new LegsItem(5001, "Iron Leggings", 20, 1, 3, 0, true);
        }
    }
}

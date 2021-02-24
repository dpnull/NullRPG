using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class LegsItem : Item
    {
        private LegsItem(int id, string name, string description, int gold, int level, int defense, int health, bool isUnique)
            : base(id, name, description, gold, level, 0, 0, defense, health, true)
        {

        }

        public static LegsItem IronLeggings()
        {
            return new LegsItem(5001, "Iron Leggings", "Encumbers you but packs good resistance.", 20, 1, 3, 0, true);
        }
    }
}

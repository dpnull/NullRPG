using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class HeadItem : Item
    {
        private HeadItem(int id, string name, int gold, int level, int defense, int health, bool isUnique)
            : base(id, name, gold, isUnique, level, 0, 0, defense, health)
        {

        }

        public static HeadItem IronHelmet()
        {
            return new HeadItem(3001, "Iron Helmet", 12, 1, 4, 0, true);
        }

        public static HeadItem LivingLogHelmet()
        {
            return new HeadItem(3002, "Living Log Helmet", 50, 1, 1, 50, true);
        }
    }
}

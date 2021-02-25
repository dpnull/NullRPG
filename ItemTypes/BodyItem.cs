using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class BodyItem : Item
    {
        private BodyItem(int id, string name, int gold, int level, int defense, int health, bool isUnique)
            : base(id, name, gold, level, 0, 0, defense, health, true)
        {

        }

        public static BodyItem IronArmor()
        {
            return new BodyItem(4001, "Iron Armor", 12, 1, 4, 0, true);
        }

        public static BodyItem ThornsArmor()
        {
            return new BodyItem(4002, "Thorns Armor", 120, 17, 5, -25, true);
        }
    }
}

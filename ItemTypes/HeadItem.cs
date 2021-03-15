using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Head Item]")]
    public class HeadItem : Item
    {
        public HeadItem(string name, Rarities rarity, int level, int durability, int gold, int defense) :
            base(name, rarity, true, level, durability, gold, 0, 0, defense)
        {
        }

        public static HeadItem None()
        {
            return new HeadItem("None", Rarities.Common, 0, 0, 0, 0);
        }

        public static HeadItem IronHelmet()
        {
            return new HeadItem("Iron Helmet", Rarities.Common, 1, 100, 8, 4);
        }
    }
}
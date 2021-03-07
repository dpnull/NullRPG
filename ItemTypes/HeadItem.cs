using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[HeadItem]")]
    public class HeadItem : Item
    {
        public HeadItem(string name, RarityType rarity, int level, int gold, int defense) :
            base(name, rarity, true, level, gold, 0, 0, defense)
        {

        }
        public static HeadItem None()
        {
            return new HeadItem("None", RarityType.Common, 0, 0, 0);
        }

        public static HeadItem IronHelmet()
        {
            return new HeadItem("Iron Helmet", RarityType.Common, 1, 8, 4);
        }
    }
}

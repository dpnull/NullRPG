using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[BodyItem]")]
    public class BodyItem : Item
    {
        public BodyItem(string name, RarityType rarity, int level, int gold, int defense) :
            base(name, rarity, true, level, gold, 0, 0, defense)
        {

        }

        public static BodyItem None()
        {
            return new BodyItem("None", RarityType.Common, 0, 0, 0);
        }

        public static BodyItem IronChestplate()
        {
            return new BodyItem("Iron Chestplate", RarityType.Common, 1, 12, 7);
        }
    }
}

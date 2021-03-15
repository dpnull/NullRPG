using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Body Item]")]
    public class BodyItem : Item
    {
        public BodyItem(string name, Rarities rarity, int level, int durability, int gold, int defense) :
            base(name, rarity, true, level, durability, gold, 0, 0, defense)
        {
        }

        public static BodyItem None()
        {
            return new BodyItem("None", Rarities.Common, 0, 0, 0, 0);
        }

        public static BodyItem IronChestplate()
        {
            return new BodyItem("Iron Chestplate", Rarities.Common, 1, 100, 12, 7);
        }
    }
}
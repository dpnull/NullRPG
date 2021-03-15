using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Legs Item]")]
    public class LegsItem : Item
    {
        public LegsItem(string name, Rarities rarity, int level, int durability, int gold, int defense) :
            base(name, rarity, true, level, gold, 0, 0, defense)
        {
        }

        public static LegsItem None()
        {
            return new LegsItem("None", Rarities.Common, 0, 0, 0, 0);
        }

        public static LegsItem IronLeggings()
        {
            return new LegsItem("Iron Leggins", Rarities.Common, 1, 100, 10, 5);
        }
    }
}
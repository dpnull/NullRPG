using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Legs Item]")]
    public class LegsItem : Item
    {
        public LegsItem(string name, RarityType rarity, int level, int gold, int defense) :
            base(name, rarity, true, level, gold, 0, 0, defense)
        {
        }

        public static LegsItem None()
        {
            return new LegsItem("None", RarityType.Common, 0, 0, 0);
        }

        public static LegsItem IronLeggings()
        {
            return new LegsItem("Iron Leggins", RarityType.Common, 1, 10, 5);
        }
    }
}
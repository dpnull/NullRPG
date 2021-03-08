using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Misc Item]")]
    public class MiscItem : Item
    {
        // In the future, if items should have randomized stats, create a factory then pass the already instantiated objects for the return
        public MiscItem(string name, RarityType rarity, bool isUnique, int level, int gold) : base(name, rarity, isUnique, level, gold)
        {

        }

        public static MiscItem Quartz()
        {
            return new MiscItem("Quartz", RarityType.Common, false, 1, 25);
        }

        public static MiscItem GoldBar()
        {
            return new MiscItem("Gold bar", RarityType.Rare, false, 1, 70);
        }
    }
}

using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Misc Item]")]
    public class MiscItem : Item
    {
        // In the future, if items should have randomized stats, create a factory then pass the already instantiated objects for the return
        public MiscItem(string name, Rarities rarity, bool isUnique, int level, int gold) : base(name, rarity, isUnique, level, gold)
        {
        }

        public static MiscItem Quartz()
        {
            return new MiscItem("Quartz", Rarities.Common, false, 1, 25);
        }

        public static MiscItem GoldBar()
        {
            return new MiscItem("Gold bar", Rarities.Rare, false, 1, 70);
        }

        public static MiscItem BirchnutRawLog()
        {
            return new MiscItem("Birchnut raw log", Rarities.Common, false, 1, 5);
        }
    }
}
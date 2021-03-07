using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class MiscItem : Item
    {
        public MiscItem(string name, int gold, RarityType rarity) : base(name, gold, rarity, false)
        {

        }

        public static MiscItem Quartz()
        {
            return new MiscItem("Quartz", 50, RarityType.Common);
        }

        public static MiscItem GoldBar()
        {
            return new MiscItem("Gold bar", 300, RarityType.Rare);
        }
    }
}

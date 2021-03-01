using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class MiscItem : Item
    {
        public MiscItem(string name, int gold) : base(name, gold, false)
        {

        }

        public static MiscItem Quartz()
        {
            return new MiscItem("Quartz", 50);
        }
    }
}

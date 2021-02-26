using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class HeadItem : Item
    {

        public static HeadItem IronHelmet()
        {
            return Item
        }

        public static HeadItem LivingLogHelmet()
        {
            return new HeadItem(3002, "Living Log Helmet", 50, 1, 1, 50, true);
        }
    }
}

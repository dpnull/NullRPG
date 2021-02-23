using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.ItemTypes
{
    public class MiscItem : Item
    {
        private MiscItem(int id, string name, string description, int gold) : base(id, name, description, gold)
        {

        }

        public static Item SpiderSilk()
        {
            return new MiscItem(1001, "Spider Silk", "Silky silk.", 3);
        }
        public static Item BoarSkin()
        {
            return new MiscItem(1001, "Boar Skin", "A hunter's proud treasure.", 4);
        }
    }
}

using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects.Slots
{
    class HeadSlot : Slot
    {
        public HeadSlot(Item item) : base(item, 1)
        {

        }

        public override void ReplaceItem(Item item)
        {
            if (item is HeadItem)
            {
                Item = item;
            }
        }
    }
}

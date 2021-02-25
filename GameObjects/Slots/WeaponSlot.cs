using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects.Slots
{
    class WeaponSlot : Slot
    {
        public WeaponSlot(Item item) : base(item, 1)
        {

        }

        public override void ReplaceItem(Item item)
        {
            if (item is WeaponItem)
            {
                Item = item;
            }
        }
    }
}

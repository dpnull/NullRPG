using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NullRPG.ItemTypes;

namespace NullRPG.GameObjects
{
    public class InventorySlot
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public InventorySlot(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

    }
}

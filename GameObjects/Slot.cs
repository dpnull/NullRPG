using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NullRPG.ItemTypes;

namespace NullRPG.GameObjects
{
    public class Slot
    {
        public Item Item { get; set; } // todo: change setter to private
        public int Quantity { get; private set; }

        internal Slot(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public virtual void ReplaceItem(Item item)
        {
            Item = item;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void IncrementQuantity()
        {
            Quantity++;
        }

        public void DecrementQuantity()
        {
            Quantity--;
        }
    }
}

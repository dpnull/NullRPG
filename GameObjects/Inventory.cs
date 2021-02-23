using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NullRPG.GameObjects
{
    public class Inventory
    {
        private List<Item> _inventory { get; set; }

        public Inventory()
        {
            _inventory = new List<Item>();
        }

        public void AddItemToInventory(Item item)
        {
            _inventory.Add(item);
        }

        public void RemoveItemFromInventory(Item item)
        {
            _inventory.Remove(item);
        }

        public Item[] GetInventory()
        {
            return _inventory.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NullRPG.ItemTypes;

namespace NullRPG.GameObjects
{
    public class Inventory
    {
        private List<Item> _inventory { get; set; }
        private WeaponItem CurrentWeapon { get; set; }

        public Inventory()
        {
            _inventory = new List<Item>();
            CurrentWeapon = WeaponItem.Barehanded();
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

        public WeaponItem GetCurrentWeapon()
        {
            return CurrentWeapon;
        }
    }
}

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
        private HeadItem CurrentHeadItem { get; set; }
        private BodyItem CurrentBodyItem { get; set; }
        private LegsItem CurrentLegsItem { get; set; }

        public Inventory()
        {
            _inventory = new List<Item>();
            CurrentWeapon = WeaponItem.Barehanded();
            CurrentHeadItem = HeadItem.LivingLogHelmet();
            CurrentBodyItem = BodyItem.ThornsArmor();
            CurrentLegsItem = LegsItem.IronLeggings();
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

        public HeadItem GetCurrentHeadItem()
        {
            return CurrentHeadItem;
        }
        public BodyItem GetCurrentBodyItem()
        {
            return CurrentBodyItem;
        }

        public LegsItem GetCurrentLegsItem()
        {
            return CurrentLegsItem;
        }
    }
}

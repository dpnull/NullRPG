using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NullRPG.GameObjects
{
    public class Inventory
    {
        private WeaponItem CurrentWeapon { get; set; }
        private HeadItem CurrentHeadItem { get; set; }
        private BodyItem CurrentBodyItem { get; set; }
        private LegsItem CurrentLegsItem { get; set; }

        private List<InventorySlot> _inventory = new List<InventorySlot>();

        public Inventory()
        {
            CurrentWeapon = WeaponItem.Barehanded();
            CurrentHeadItem = HeadItem.IronHelmet();
            CurrentBodyItem = BodyItem.IronArmor();
            CurrentLegsItem = LegsItem.IronLeggings();
        }

        public void AddItemToInventory(Item item)
        {
            if (item.IsUnique)
            {
                _inventory.Add(new InventorySlot(item, 1));
            }
            else
            {
                if(!_inventory.Any(i => i.Item.ID == item.ID))
                {
                    _inventory.Add(new InventorySlot(item, 0));
                }

                _inventory.First(i => i.Item.ID == item.ID).Quantity++;
            }
        }

        public InventorySlot[] GetInventory()
        {
            return _inventory.ToArray();
        }
        public InventorySlot[] GetMisc()
        {
            var misc = new List<InventorySlot>();
            foreach(var item in _inventory)
            {
                if (item.Item is MiscItem)
                {
                    misc.Add(item);
                }
            }
            return misc.ToArray();
        }

        public InventorySlot[] GetEquipment()
        {
            var equipment = new List<InventorySlot>();
            foreach (var item in _inventory)
            {
                if (item.Item is WeaponItem || item.Item is HeadItem || item.Item is BodyItem || item.Item is LegsItem)
                {
                    equipment.Add(item);
                }
            }
            return equipment.ToArray();
        }

        public InventorySlot GetCurrentWeapon()
        {
            return new InventorySlot(CurrentWeapon, 1);
        }

        public InventorySlot GetCurrentHeadItem()
        {
            return new InventorySlot(CurrentHeadItem, 1);
        }
        public InventorySlot GetCurrentBodyItem()
        {
            return new InventorySlot(CurrentBodyItem, 1);
        }

        public InventorySlot GetCurrentLegsItem()
        {
            return new InventorySlot(CurrentLegsItem, 1);
        }

        public void EquipWeaponItem(WeaponItem item)
        {
            CurrentWeapon = item;
        }
        public void EquipHeadItem(HeadItem item)
        {
            CurrentHeadItem = item;
        }
        public void EquipBodyItem(BodyItem item)
        {
            CurrentBodyItem = item;
        }
        public void EquipLegsItem(LegsItem item)
        {
            CurrentLegsItem = item;
        }
    }
}

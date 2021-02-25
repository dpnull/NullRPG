using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NullRPG.GameObjects.Slots;

namespace NullRPG.GameObjects
{
    public class Inventory
    {
        private List<Slot> _inventory = new List<Slot>();

        private WeaponSlot CurrentWeapon { get; set; }
        private HeadSlot CurrentHeadItem { get; set; }
        private BodySlot CurrentBodyItem { get; set; }
        private LegsSlot CurrentLegsItem { get; set; }

        public Inventory()
        {
            CurrentWeapon = new WeaponSlot(WeaponItem.Broadsword());
            CurrentHeadItem = new HeadSlot(HeadItem.IronHelmet());
            CurrentBodyItem = new BodySlot(BodyItem.IronArmor());
            CurrentLegsItem = new LegsSlot(LegsItem.IronLeggings());
        }

        public void AddItemToInventory(Item item)
        {
            if (item.IsUnique)
            {
                // YOU WERE WORKING ON ACCESS MODIFIERS
                _inventory.Add(new Slot(item, 1));
            }
            else
            {
                if(!_inventory.Any(i => i.Item.ID == item.ID))
                {
                    _inventory.Add(new Slot(item, 0));
                }

                _inventory.First(i => i.Item.ID == item.ID).IncrementQuantity();
            }
        }

        public Slot[] GetInventory()
        {
            return _inventory.ToArray();
        }

        public Slot[] GetMisc()
        {
            var misc = new List<Slot>();
            foreach(var item in _inventory)
            {
                if (item.Item is MiscItem)
                {
                    misc.Add(item);
                }
            }
            return misc.ToArray();
        }

        public Slot[] GetEquipment()
        {
            var equipment = new List<Slot>();
            foreach (var item in _inventory)
            {
                if (item.Item is WeaponItem || item.Item is HeadItem || item.Item is BodyItem || item.Item is LegsItem)
                {
                    equipment.Add(item);
                }
            }
            return equipment.ToArray();
        }

        public Slot GetCurrentWeapon()
        {
            return CurrentWeapon;
        }

        public Slot GetCurrentHeadItem()
        {
            return CurrentHeadItem;
        }
        public Slot GetCurrentBodyItem()
        {
            return CurrentBodyItem;
        }

        public Slot GetCurrentLegsItem()
        {
            return CurrentLegsItem;
        }

        public void EquipWeaponItem(WeaponItem item)
        {
            CurrentWeapon.ReplaceItem(item);
        }
        public void EquipHeadItem(HeadItem item)
        {
            CurrentHeadItem.ReplaceItem(item);
        }
        public void EquipBodyItem(BodyItem item)
        {
            CurrentBodyItem.ReplaceItem(item);
        }
        public void EquipLegsItem(LegsItem item)
        {
            CurrentLegsItem.ReplaceItem(item);
        }
    }
}

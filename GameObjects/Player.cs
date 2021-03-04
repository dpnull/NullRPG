using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullRPG.GameObjects
{
    public class Player : Entity
    {
        public int Experience { get; set; }
        public int ExperienceNeeded { get; set; }

        private readonly Inventory _inventory;

        public Player() : base("Tianyu", 100, 20, 1)
        {
            // Probably shouldn't be here
            ItemManager.Add(WeaponItem.None());

            Experience = 0;
            ExperienceNeeded = 100;

            CurrentWeapon = (WeaponItem)ItemManager.GetItem<IItem>(0);

            _inventory = new Inventory();

        }

        public void EquipWeaponViaSlot(int slotObjectId)
        {
            if (InventoryManager.GetSlot<ISlot>(slotObjectId).Item.Any())
            {
                var equippable = InventoryManager.GetSlot<ISlot>(slotObjectId).Item.FirstOrDefault(i => i is WeaponItem);
                CurrentWeapon = (WeaponItem)equippable;
            }
        }

        public void EquipWeapon(int itemObjectId)
        {
            if (ItemManager.GetItem<IItem>(itemObjectId) != null)
            {
                var equippable = ItemManager.GetItem<IItem>(itemObjectId);
                CurrentWeapon = (WeaponItem)equippable;
            }
        }

        public string GetWeaponName()
        {
            return CurrentWeapon?.Name.ToString();
        }
    }
}

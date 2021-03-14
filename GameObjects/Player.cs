﻿using NullRPG.GameObjects.Worlds;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using System.Linq;

namespace NullRPG.GameObjects
{
    public class Player : Entity
    {
        public int Experience { get; set; }
        public int ExperienceNeeded { get; set; }

        //public PlayerInventory Inventory { get; set; }
        public Player() : base("Tianyu", 100, 20, 1)
        {
            Inventory = new PlayerInventory();

            Experience = 0;
            ExperienceNeeded = 100;

            Inventory.CurrentWeapon = (WeaponItem)ItemManager.GetItem<IItem>(0);

            CurrentWorld = WorldManager.Get<Overworld>();
            CurrentArea = (Area)AreaManager.GetAreaByObjectId<IArea>(CurrentWorld.Areas.First().Value.ObjectId);
            CurrentLocation = (Location)LocationManager.GetLocationByObjectId<ILocation>(CurrentArea.Locations.First().Value.ObjectId);
        }

        /*
        public void EquipWeaponViaSlot(int slotObjectId)
        {
            if (InventoryManager.GetSlot<ISlot>(PlayerInventory, slotObjectId).Item.Any())
            {
                var equippable = InventoryManager.GetSlot<ISlot>(PlayerInventory, slotObjectId).Item.FirstOrDefault(i => i is WeaponItem);
                CurrentWeapon = (WeaponItem)equippable;
            }
        }
        */
    }
}
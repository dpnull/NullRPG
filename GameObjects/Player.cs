using NullRPG.GameObjects.Worlds;
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
        public World CurrentWorld { get; set; }
        public Area CurrentArea { get; set; }
        public Location CurrentLocation { get; set; }

        //public PlayerInventory Inventory { get; set; }
        public Player() : base("Tianyu", 100, 20, 1)
        {
            Inventory = new PlayerInventory();

            // Probably shouldn't be here
            ItemManager.Add(WeaponItem.None());

            Experience = 0;
            ExperienceNeeded = 100;

            Inventory.CurrentWeapon = (WeaponItem)ItemManager.GetItem<IItem>(0);

            CurrentWorld = WorldManager.Get<Overworld>();
            CurrentArea = (Area)CurrentWorld.Areas.First().Value;
            CurrentArea = (Area)WorldManager.GetWorldArea<Overworld>("Hometown");

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

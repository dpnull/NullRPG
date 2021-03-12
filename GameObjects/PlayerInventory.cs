using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NullRPG.GameObjects
{
    public class PlayerInventory : EntityInventory
    {
        public PlayerInventory() : base()
        {
            // init default inventory
            InventoryManager.Add(this);
            
            InventoryManager.CreateDefault<PlayerInventory>();

            CurrentWeapon = WeaponItem.None();
            CurrentHeadItem = HeadItem.None();
            CurrentBodyItem = BodyItem.None();
            CurrentLegsItem = LegsItem.None();

            InventoryManager.AddToInventory<PlayerInventory>(WeaponItem.Longsword());
            InventoryManager.AddToInventory<PlayerInventory>(HeadItem.IronHelmet());
            InventoryManager.AddToInventory<PlayerInventory>(BodyItem.IronChestplate());
            InventoryManager.AddToInventory<PlayerInventory>(LegsItem.IronLeggings());

            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());

            InventoryManager.AddToInventory<PlayerInventory>(WeaponItem.Longsword());
            InventoryManager.AddToInventory<PlayerInventory>(HeadItem.IronHelmet());
           
            InventoryManager.AddToInventory<PlayerInventory>(LegsItem.IronLeggings());
            InventoryManager.AddToInventory<PlayerInventory>(WeaponItem.Oliaxe());

            
        }
    }
}

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

            InventoryManager.AddToInventory<PlayerInventory>(WeaponItem.Axe());
            InventoryManager.AddToInventory<PlayerInventory>(WeaponItem.Axe());
            InventoryManager.AddToInventory<PlayerInventory>(WeaponItem.Longsword());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());
            InventoryManager.AddToInventory<PlayerInventory>(MiscItem.Quartz());


        }
    }
}

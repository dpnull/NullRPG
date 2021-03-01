using NullRPG.ItemTypes;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public class Inventory
    {
        public Inventory()
        {
            InventoryManager.CreateDefault();

            InventoryManager.AddToInventory(MiscItem.Quartz());
            InventoryManager.AddToInventory(MiscItem.Quartz());
            InventoryManager.AddToInventory(MiscItem.Quartz());
            InventoryManager.AddToInventory(MiscItem.Quartz());

            InventoryManager.AddToInventory(WeaponItem.Axe());
            InventoryManager.AddToInventory(WeaponItem.Longsword());
            InventoryManager.AddToInventory(WeaponItem.Axe());
            InventoryManager.AddToInventory(WeaponItem.Longsword());
            InventoryManager.AddToInventory(WeaponItem.Longsword());
        }
    }
}

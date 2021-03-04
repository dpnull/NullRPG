using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            InventoryManager.AddToInventory(MiscItem.Quartz());
            InventoryManager.AddToInventory(WeaponItem.Longsword());
            InventoryManager.AddToInventory(WeaponItem.Longsword());
            InventoryManager.AddToInventory(MiscItem.Quartz());
            InventoryManager.AddToInventory(MiscItem.Quartz());

            Enchant.EnchantSteel(ItemManager.GetItems<IItem>().FirstOrDefault(i => i is WeaponItem && i.ObjectId!=0));
        }
    }
}

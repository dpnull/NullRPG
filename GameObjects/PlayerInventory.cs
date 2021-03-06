using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public class PlayerInventory : EntityInventory
    {
        public PlayerInventory() : base()
        {
            // init default inventory
            InventoryManager.CreateDefault(this);

            InventoryManager.AddToInventory<IEntityInventory>(this, WeaponItem.Axe());
        }
    }
}

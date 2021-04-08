﻿using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Items.Armors;
using NullRPG.GameObjects.Items.Misc;
using NullRPG.GameObjects.Items;
using NullRPG.Managers;

namespace NullRPG.GameObjects.Entity
{
    public class Player : BaseEntity
    {
        public Player() : base("Dom")
        {
            EntityComponent entity = new EntityComponent(this);
            Components.Add(entity);
            EntityComponentValue entityValue = new EntityComponentValue(100, 2, 35);
            ReceiveComponentValue(entityValue);

            InventoryComponent inventory = new InventoryComponent(this);
            Components.Add(inventory);
            InventoryComponentValue inventoryValue = new InventoryComponentValue(new PlayerInventory());
            ReceiveComponentValue(inventoryValue);

            InventoryManager.AddToInventory(this, Misc.Birchwood());
            InventoryManager.AddToInventory(this, Misc.Birchwood());
            InventoryManager.AddToInventory(this, Misc.Birchwood());
        }
    }
}
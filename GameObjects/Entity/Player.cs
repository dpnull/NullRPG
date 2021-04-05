using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.GameObjects.Items.Misc;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Entity
{
    public class Player : BaseEntity
    {
        public Player() : base()
        {
            EntityComponent entity = new EntityComponent(this);
            Components.Add(entity);
            EntityComponentValue entityValue = new EntityComponentValue(100, 2, 35);
            ReceiveComponentValue(entityValue);

            InventoryComponent inventory = new InventoryComponent(this);
            Components.Add(inventory);
            InventoryComponentValue inventoryValue = new InventoryComponentValue(new PlayerInventory());
            ReceiveComponentValue(inventoryValue);

            InventoryManager.AddToInventory(this, new Longsword());
            InventoryManager.AddToInventory(this, new Longsword());
            InventoryManager.AddToInventory(this, new Birchwood());
            InventoryManager.AddToInventory(this, new Birchwood());
            InventoryManager.AddToInventory(this, new Birchwood());
            InventoryManager.AddToInventory(this, new Birchwood());
            InventoryManager.AddToInventory(this, new Birchwood());
            InventoryManager.AddToInventory(this, new IronHelmet());
            InventoryManager.AddToInventory(this, new IronHelmet());
        }
    }
}

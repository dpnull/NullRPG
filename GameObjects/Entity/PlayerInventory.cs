using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Entity
{
    public class PlayerInventory : EntityInventory
    {
        public PlayerInventory() : base()
        {
            InventoryManager.Add(this);
            InventoryManager.CreateDefault<PlayerInventory>();

            InventoryManager.AddToInventory<PlayerInventory>(new Longsword());
            InventoryManager.AddToInventory<PlayerInventory>(new Longsword());
            InventoryManager.AddToInventory<PlayerInventory>(new IronHelmet());

        }
    }
}

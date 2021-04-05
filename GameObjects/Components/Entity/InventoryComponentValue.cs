using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.Entity
{
    public class InventoryComponentValue
    {
        public EntityInventory Inventory { get; set; }

        public InventoryComponentValue(EntityInventory inventory)
        {
            Inventory = inventory;
        }
    }
}

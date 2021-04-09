using NullRPG.GameObjects.Abstracts;

namespace NullRPG.GameObjects.Components.Entity
{
    public class InventoryComponentValue
    {
        public EntityInventory Inventory;

        public InventoryComponentValue(EntityInventory inventory)
        {
            Inventory = inventory;
        }
    }
}
using NullRPG.GameObjects.Abstracts;
using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Components.Entity
{
    public class InventoryComponent : IEntityComponent
    {
        public EntityInventory Inventory { get; set; }
        public IEntity Source { get; set; }

        public InventoryComponent(IEntity source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            InventoryComponentValue inventoryValue = value as InventoryComponentValue;
            Inventory = inventoryValue.Inventory;
        }
    }
}
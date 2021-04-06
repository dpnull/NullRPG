using NullRPG.Interfaces;
using System.Collections.Generic;

namespace NullRPG.GameObjects.Components.Item
{
    internal class ItemTypeComponent : IItemComponent
    {
        public List<Enums.ItemTypes> ItemTypes { get; private set; } = new List<Enums.ItemTypes>();
        public IItem Source { get; set; }

        public ItemTypeComponent(IItem source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            ItemTypeComponentValue itemTypeValue = value as ItemTypeComponentValue;
            if (itemTypeValue != null)
            {
                ItemTypes.Add(itemTypeValue.ItemType);
            }
        }
    }
}
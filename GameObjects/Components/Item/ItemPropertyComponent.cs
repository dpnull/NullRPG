using NullRPG.Interfaces;
using System.Collections.Generic;

namespace NullRPG.GameObjects.Components.Item
{
    public class ItemPropertyComponent : IItemComponent
    {
        public List<Enums.ItemProperties> ItemProperties { get; private set; } = new List<Enums.ItemProperties>();
        public IItem Source { get; set; }
        public ItemPropertyComponent(IItem source)
        {
            Source = source;
        }
        public void ReceiveValue<T>(T value)
        {
            ItemPropertyComponentValue itemPropertyComponentValue = value as ItemPropertyComponentValue;
            if (itemPropertyComponentValue != null)
            {
                ItemProperties.Add(itemPropertyComponentValue.ItemProperty);
            }
        }
    }
}

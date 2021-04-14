using NullRPG.Interfaces;
using System.Collections.Generic;


namespace NullRPG.GameObjects.Components.Item
{
    internal class EquippableTypeComponent : IItemComponent
    {
        public Enums.EquippableTypes EquippableType { get; private set; }
        public IItem Source { get; set; }

        public EquippableTypeComponent(IItem source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            EquippableTypeComponentValue equippableTypeComponentValue = value as EquippableTypeComponentValue;
            if (equippableTypeComponentValue != null)
            {
                EquippableType = equippableTypeComponentValue.EquippableType;
            }
        }
    }
}

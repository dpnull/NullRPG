﻿using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Components.Item
{
    public class ArmorComponent : IItemComponent
    {
        public int Defense { get; private set; }

        public IItem Source { get; set; }

        public ArmorComponent(IItem source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            ArmorComponentValue armorValue = value as ArmorComponentValue;
            if (armorValue != null)
            {
                Defense = armorValue.Defense;
            }
        }
    }
}
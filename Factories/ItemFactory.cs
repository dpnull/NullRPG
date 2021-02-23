using NullRPG.GameObjects;
using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Factories
{
    public static class ItemFactory
    {
        private static List<Item> _items = new List<Item>();

        static ItemFactory()
        {
            _items.Add(MiscItem.BoarSkin());
            _items.Add(MiscItem.SpiderSilk());
            _items.Add(WeaponItem.Broadsword());
            _items.Add(WeaponItem.Longsword());
            _items.Add(WeaponItem.Longsword());
        }
    }
}

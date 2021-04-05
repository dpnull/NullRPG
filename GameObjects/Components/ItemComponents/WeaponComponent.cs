using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.ItemComponents
{
    public class WeaponComponent : IComponent
    {
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public IItem Source { get; set; }

        public WeaponComponent(IItem source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            WeaponComponentValue weaponValue = value as WeaponComponentValue;
            if (weaponValue != null)
            {
                MinDamage = weaponValue.MinDamage;
                MaxDamage = weaponValue.MaxDamage;
            }
        }
    }
}

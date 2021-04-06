using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Components.Item
{
    public class WeaponComponent : IItemComponent
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
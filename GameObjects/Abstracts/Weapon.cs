using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Weapon : BaseItem
    {
        public Weapon(string name, int minDmg, int maxDmg, int value) : base(Enums.ItemCategories.Weapon, name, value)
        {
            WeaponComponent weaponComponent = new WeaponComponent(this);
            Components.Add(weaponComponent);
            WeaponComponentValue weaponComponentValue = new WeaponComponentValue(minDmg, maxDmg);
            ReceiveComponentValue(weaponComponentValue);

            // Once there are more weapon types, create a wrapper.
            ItemTypeComponent weaponItemTypeComponent = new ItemTypeComponent(this);
            Components.Add(weaponItemTypeComponent);
            ItemTypeComponentValue weaponItemTypeComponentValue = new ItemTypeComponentValue(Enums.ItemTypes.Equippable);
            ReceiveComponentValue(weaponItemTypeComponentValue);

            // refer to Enums.cs
            EquippableTypeComponent equippableTypeComponent = new EquippableTypeComponent(this);
            Components.Add(equippableTypeComponent);
            EquippableTypeComponentValue equippableTypeComponentValue = new EquippableTypeComponentValue(Enums.EquippableTypes.Hands);
            ReceiveComponentValue(equippableTypeComponentValue);

            // Currently by default all weapon items are equippable
            ItemPropertyComponent weaponProperty = new ItemPropertyComponent(this);
            Components.Add(weaponProperty);
            ItemPropertyComponentValue weaponPropertyValue = new ItemPropertyComponentValue(Enums.ItemProperties.Equippable);
            ReceiveComponentValue(weaponPropertyValue);
        }
    }
}
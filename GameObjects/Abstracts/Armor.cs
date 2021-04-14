using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Armor : BaseItem
    {

        public Armor(string name, int defense, Enums.EquippableTypes equippableType, int value) : base(Enums.ItemCategories.Armor, name, value)
        {
            ArmorComponent armorComponent = new ArmorComponent(this);
            Components.Add(armorComponent);

            ArmorComponentValue armorComponentValue = new ArmorComponentValue(defense);
            ReceiveComponentValue(armorComponentValue);

            ItemTypeComponent armorSubType = new ItemTypeComponent(this);
            Components.Add(armorSubType);
            // refer to Enums.cs
            ItemTypeComponentValue armorTypeValue = new ItemTypeComponentValue(Enums.ItemTypes.Equippable);
            ReceiveComponentValue(armorTypeValue);

            EquippableTypeComponent equippableTypeComponent = new EquippableTypeComponent(this);
            Components.Add(equippableTypeComponent);
            EquippableTypeComponentValue equippableTypeComponentValue = new EquippableTypeComponentValue(equippableType);
            ReceiveComponentValue(equippableTypeComponentValue);

            // Currently by default all armor items are equippable
            ItemPropertyComponent armorProperty = new ItemPropertyComponent(this);
            Components.Add(armorProperty);
            ItemPropertyComponentValue armorPropertyValue = new ItemPropertyComponentValue(Enums.ItemProperties.Equippable);
            ReceiveComponentValue(armorPropertyValue);
        }
    }
} 
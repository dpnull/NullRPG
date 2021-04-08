using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Armor : BaseItem
    {
        public enum ArmorTypeWrapper
        {
            Head,
            Chest,
            Legs
        };

        public Armor(string name, int defense, ArmorTypeWrapper armorType, int value) : base(Enums.ItemCategories.Armor, name, value)
        {
            ArmorComponent armorComponent = new ArmorComponent(this);
            Components.Add(armorComponent);

            ArmorComponentValue armorComponentValue = new ArmorComponentValue(defense);
            ReceiveComponentValue(armorComponentValue);

            ItemTypeComponent armorSubType = new ItemTypeComponent(this);
            Components.Add(armorSubType);
            ItemTypeComponentValue armorTypeValue = new ItemTypeComponentValue(GetItemType(armorType));
            ReceiveComponentValue(armorTypeValue);
        }

        public Enums.ItemTypes GetItemType(ArmorTypeWrapper armorType)
        {
            return armorType switch
            {
                ArmorTypeWrapper.Head => Enums.ItemTypes.HeadArmor,
                ArmorTypeWrapper.Chest => Enums.ItemTypes.ChestArmor,
                ArmorTypeWrapper.Legs => Enums.ItemTypes.LegsArmor,
                _ => throw new System.Exception($"{nameof(armorType)} is invalid."),
            };
        }
    }
} 
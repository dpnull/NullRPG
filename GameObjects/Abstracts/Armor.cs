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

        private static Enums.ItemTypes GetItemType(ArmorTypeWrapper armorType)
        {
            switch (armorType)
            {
                case ArmorTypeWrapper.Head:
                    return Enums.ItemTypes.HeadArmor;
                case ArmorTypeWrapper.Chest:
                    return Enums.ItemTypes.ChestArmor;
                case ArmorTypeWrapper.Legs:
                    return Enums.ItemTypes.LegsArmor;
                default:
                    throw new System.Exception($"{nameof(armorType)} is invalid.");
            }
        }
    }
} 
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Abstracts
{
    public class Miscellaneous : BaseItem
    {
        public enum MiscTypeWrapper
        {
            Material
        }

        public Miscellaneous(string name, int value) : base(Enums.ItemCategories.Misc, name, value)
        {
            IsStackable = true;

            Value = 5;

            ItemTypeComponent miscTypeComponent = new ItemTypeComponent(this);
            Components.Add(miscTypeComponent);

            ItemTypeComponentValue miscTypeComponentValue = new ItemTypeComponentValue(Enums.ItemTypes.Sword);
            ReceiveComponentValue(miscTypeComponentValue);

        }

        public void AddItemType(MiscTypeWrapper miscType)
        {
            ItemTypeComponentValue newTypeComponent = new ItemTypeComponentValue(GetItemType(miscType));
            ReceiveComponentValue(newTypeComponent);
        }

        public static Enums.ItemTypes GetItemType(MiscTypeWrapper miscType)
        {
            return miscType switch
            {
                MiscTypeWrapper.Material => Enums.ItemTypes.Material,
                _ => throw new System.Exception($"{nameof(miscType)} is invalid."),
            };
        }

        
    }
}
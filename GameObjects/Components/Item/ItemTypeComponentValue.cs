namespace NullRPG.GameObjects.Components.Item
{
    public class ItemTypeComponentValue
    {
        public Enums.ItemTypes ItemType { get; private set; }

        public ItemTypeComponentValue(Enums.ItemTypes itemType)
        {
            ItemType = itemType;
        }
    }
}
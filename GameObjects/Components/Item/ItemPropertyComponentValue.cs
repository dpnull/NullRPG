namespace NullRPG.GameObjects.Components.Item
{
    public class ItemPropertyComponentValue
    {
        public Enums.ItemProperties ItemProperty { get; private set; }

        public ItemPropertyComponentValue(Enums.ItemProperties itemProperty)
        {
            ItemProperty = itemProperty;
        }
    }
}

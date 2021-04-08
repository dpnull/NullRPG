namespace NullRPG.GameObjects.Abstracts
{
    public class Miscellaneous : BaseItem
    {
        public enum MiscTypeWrapper
        {
            Misc,
            Material
        }

        public Miscellaneous(string name, int value, ) : base(Enums.ItemCategories.Misc, name, value)
        {
            IsStackable = true;

            Value = 5;

            ItemTypeComponent birchwoodAtt = new ItemTypeComponent(this);
            Components.Add(birchwoodAtt);

            ItemTypeComponentValue birchwoodMsg = new ItemTypeComponentValue(Enums.ItemTypes.Misc);
            ReceiveComponentValue(birchwoodMsg);
            ItemTypeComponentValue birchwoodMsg2 = new ItemTypeComponentValue(Enums.ItemTypes.Material);
            ReceiveComponentValue(birchwoodMsg2);
        }

        public static Enums.ItemTypes GetItemType()
        {

        }

        
    }
}
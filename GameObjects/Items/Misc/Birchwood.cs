using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Misc
{
    public class Birchwood : Miscellaneous
    {
        public Birchwood() : base("Birchwood")
        {
            Value = 5;

            ItemTypeComponent birchwoodAtt = new ItemTypeComponent(this);
            Components.Add(birchwoodAtt);

            ItemTypeComponentValue birchwoodMsg = new ItemTypeComponentValue(Enums.ItemTypes.Misc);
            ReceiveComponentValue(birchwoodMsg);
            ItemTypeComponentValue birchwoodMsg2 = new ItemTypeComponentValue(Enums.ItemTypes.Material);
            ReceiveComponentValue(birchwoodMsg2);
        }
    }
}
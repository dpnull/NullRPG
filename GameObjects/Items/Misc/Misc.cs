using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Misc
{
    public class Misc : Miscellaneous
    {
        public Misc(string name, int value) : base(name, value)
        {
        }

        public static Misc Birchwood()
        {
            var birchwood = new Misc("Birchwood", 10);
            birchwood.AddItemType(MiscTypeWrapper.Material);

            return birchwood;
        }
    }
}
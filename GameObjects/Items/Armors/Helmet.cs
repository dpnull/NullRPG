using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Armors
{
    public class Helmet : Armor
    {
        public Helmet(string name, int defense, int value) : base(name, defense, Enums.EquippableTypes.Head, value)
        {   
        }

        public static Helmet IronHelmet()
        {
            return new Helmet("Iron Helmet", 4, 8);
        }

        public static Helmet None()
        {
            return new Helmet("None", 0, 0);
        }
    }
}
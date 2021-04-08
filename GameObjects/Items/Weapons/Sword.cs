using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string name, int minDmg, int maxDmg, int value) : base(name, minDmg, maxDmg, value)
        {
        }

        public static Sword Longsword()
        {
            return new Sword("Longsword", 7, 11, 15);
        }

        public static Sword None()
        {
            return new Sword("None", 0, 0, 0);
        }
    }
}
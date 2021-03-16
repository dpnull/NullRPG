using NullRPG.GameObjects;
using System.ComponentModel;

namespace NullRPG.ItemTypes
{
    [Description("[Weapon Item]")]
    public class WeaponItem : Item
    {
        public WeaponItem(string name, Item.Rarities rarity, int level, int durability, int gold, int minDmg, int maxDmg)
            : base(name, rarity, true, level, gold, durability, minDmg, maxDmg)
        {
        }

        public static WeaponItem None()
        {
            return new WeaponItem("None", Rarities.Common, 0, 0, 0, 0, 0);
        }

        public static WeaponItem Longsword()
        {
            return new WeaponItem("Longsword", Rarities.Uncommon, 1, 100, 10, 7, 12);
        }

        public static WeaponItem Oliaxe()
        {
            return new WeaponItem("Oliaxe", Rarities.Legendary, 1, 10, 100, 30, 45);
        }
    }
}
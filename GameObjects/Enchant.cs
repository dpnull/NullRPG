using NullRPG.Interfaces;
using NullRPG.Managers;

namespace NullRPG.GameObjects
{
    // This can be much better
    // Todo: perhaps add IEnchantable and go from there
    public static class Enchant
    {
        public static void Upgrade(IItem weapon)
        {
            var item = ItemManager.GetItem<IItem>(weapon.ObjectId);

            item.MinDmg += item.MinDmg * 10 / 100;
            item.MaxDmg += item.MaxDmg * 10 / 100;
        }

        private static void UpgradeSteel(IItem weapon)
        {
            var item = ItemManager.GetItem<IItem>(weapon.ObjectId);

            item.Enchantment = SteelType.SetToSteelType();
            item.MinDmg = SteelType.UpgradeMinDmg(item.MinDmg);
            item.MaxDmg = SteelType.UpgradeMaxDmg(item.MaxDmg);
            item.UpgradeLevel++;
        }

        public static void EnchantSteel(IItem weapon)
        {
            if (weapon.Enchantment == Item.Enchantments.Default)
            {
                UpgradeSteel(weapon);
            }
            else if (weapon.Enchantment == Item.Enchantments.Steel && weapon.UpgradeLevel < 10)
            {
                UpgradeSteel(weapon);
            }
        }

        private static class SteelType
        {
            public static Item.Enchantments SetToSteelType()
            {
                return Item.Enchantments.Steel;
            }

            public static int UpgradeMinDmg(int minDmg)
            {
                return minDmg + minDmg * 10 / 100;
            }

            public static int UpgradeMaxDmg(int maxDmg)
            {
                return maxDmg + maxDmg * 10 / 100;
            }
        }
    }
}
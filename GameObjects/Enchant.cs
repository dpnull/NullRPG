using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    // This can be much better
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
        }

        public static void EnchantSteel(IItem weapon)
        {
            if (weapon.Enchantment == Item.EnchantmentType.Default)
            {
                UpgradeSteel(weapon);
            }
            else if (weapon.Enchantment == Item.EnchantmentType.Steel && weapon.UpgradeLevel < 10)
            {
                UpgradeSteel(weapon);
            }
        }

        private static class SteelType
        {
            public static Item.EnchantmentType SetToSteelType()
            {
                return Item.EnchantmentType.Steel;
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

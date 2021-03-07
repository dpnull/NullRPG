using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace NullRPG.GameObjects
{
    public abstract class Item : IItem, IIndexable
    {
        
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
        public RarityType Rarity { get; set; }
        public EnchantmentType Enchantment { get; set; }
        public int UpgradeLevel { get; set; }
        public bool IsUnique { get; set; }

        public enum EnchantmentType
        {
            Default,
            Fire,
            Steel
        }

        public enum RarityType
        {
            [Description("Common")]
            Common,
            [Description("Uncommon")]
            Uncommon,
            [Description("Rare")]
            Rare,
            [Description("Ultra Rare")]
            VeryRare,
            [Description("Legendary")]
            Legendary
        }

        public Item(string name, RarityType rarity = RarityType.Common, bool isUnique = false, int level = 1, int gold = 0, int minDmg = 0, int maxDmg = 0, int defense = 0)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);

            Name = name;
            Rarity = rarity;
            IsUnique = isUnique;
            Level = level;
            Gold = gold;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Defense = defense;

            Enchantment = EnchantmentType.Default;
            UpgradeLevel = 1;
        }

    }
}

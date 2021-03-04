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

        public Item(string name, int gold, RarityType rarity, int level = 1, int minDmg = 0, int maxDmg = 0, int defense = 0, bool isUnique = false)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);

            Name = name;
            Level = level;
            Gold = gold;
            Rarity = rarity;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Defense = defense;
            IsUnique = isUnique;
            
            Enchantment = EnchantmentType.Default;
            UpgradeLevel = 1;
        }

        public Item(string name, int gold, RarityType rarity, bool isUnique = true)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);

            Name = name;
            Gold = gold;
            Rarity = rarity;
            IsUnique = isUnique;
            Level = 1;
            MinDmg = 0;
            MaxDmg = 0;
            Defense = 0;
            
            Enchantment = EnchantmentType.Default;
            UpgradeLevel = 1;

        }
        
    }
}

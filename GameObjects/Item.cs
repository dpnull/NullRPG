using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Microsoft.Xna.Framework;

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
        public int UpgradeLevel { get; set; }
        public EnchantmentType Enchantment { get; set; }
        public bool IsUnique { get; set; }

        public enum EnchantmentType
        {
            Default,
            Fire,
            Steel
        }

        public Item(string name, int gold, int level = 1, int minDmg = 0, int maxDmg = 0, int defense = 0, bool isUnique = false)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);

            Name = name;
            Level = level;
            Gold = gold;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Defense = defense;
            IsUnique = isUnique;
            UpgradeLevel = 1;
            Enchantment = EnchantmentType.Default;
        }

        public Item(string name, int gold, bool isUnique = true)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);

            Name = name;
            Gold = gold;
            IsUnique = isUnique;
            Level = 1;
            MinDmg = 0;
            MaxDmg = 0;
            Defense = 0;
            UpgradeLevel = 1;
            Enchantment = EnchantmentType.Default;

        }
        
    }
}

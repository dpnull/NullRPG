using NullRPG.Interfaces;
using NullRPG.Managers;
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
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
        public Rarities Rarity { get; set; }
        public Enchantments Enchantment { get; set; }
        public int UpgradeLevel { get; set; }
        public bool IsUnique { get; set; }

        public enum Enchantments
        {
            Default,
            Fire,
            Steel
        }

        public enum Rarities
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

        public Item(string name, Rarities rarity = Rarities.Common, bool isUnique = false, int level = 1, int gold = 0, int durability = 0, int minDmg = 0, int maxDmg = 0, int defense = 0)
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
            Durability = durability;
            MaxDurability = durability;

            Enchantment = Enchantments.Default;
            UpgradeLevel = 1;
        }
    }
}
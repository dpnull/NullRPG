using static NullRPG.GameObjects.Item;

namespace NullRPG.Interfaces
{
    public interface IItem
    {
        int ObjectId { get; set; }
        string Name { get; set; }
        int Level { get; set; }
        public RarityType Rarity { get; set; }
        int Gold { get; set; }
        int MinDmg { get; set; }
        int MaxDmg { get; set; }
        int Defense { get; set; }
        int UpgradeLevel { get; set; }
        EnchantmentType Enchantment { get; set; }
        bool IsUnique { get; set; }
    }
}
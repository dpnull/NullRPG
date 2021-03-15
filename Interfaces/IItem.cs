using static NullRPG.GameObjects.Item;

namespace NullRPG.Interfaces
{
    public interface IItem : IDrawableKeybinding
    {
        int ObjectId { get; set; }
        string Name { get; set; }
        int Level { get; set; }
        public Rarities Rarity { get; set; }
        int Gold { get; set; }
        int MinDmg { get; set; }
        int MaxDmg { get; set; }
        int Defense { get; set; }
        int UpgradeLevel { get; set; }
        int Durability { get; set; }
        int MaxDurability { get; set; }
        Enchantments Enchantment { get; set; }
        bool IsUnique { get; set; }
    }
}
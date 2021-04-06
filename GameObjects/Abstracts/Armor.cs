namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Armor : BaseItem
    {
        public Enums.ArmorTypes ArmorType { get; set; }

        public Armor(string name, Enums.ArmorTypes armorType) : base(name, Enums.ItemCategories.Armor)
        {
            ArmorType = armorType;
        }
    }
}
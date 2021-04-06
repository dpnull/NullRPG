namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Weapon : BaseItem
    {
        public Weapon(string name) : base(name, Enums.ItemCategories.Weapon)
        {
        }
    }
}
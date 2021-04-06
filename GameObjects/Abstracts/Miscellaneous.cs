namespace NullRPG.GameObjects.Abstracts
{
    public class Miscellaneous : BaseItem
    {
        public Miscellaneous(string name) : base(name, Enums.ItemCategories.Misc)
        {
            IsStackable = true;
        }
    }
}
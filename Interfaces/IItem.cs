using static NullRPG.GameObjects.Item;

namespace NullRPG.Interfaces
{
    public interface IItem : IDrawableKeybinding
    {
        int ObjectId { get; set; }
        string Name { get; }
        int Level { get; }
        int Gold { get; }
        bool IsUnique { get; }
        bool IsEquippable { get; }
    }
}
using Microsoft.Xna.Framework.Input;

namespace NullRPG.Interfaces
{
    public interface IIndexedKeybinding : IIndexable
    {
        int ObjectId { get; set; }
        Keys Key { get; set; }
    }
}
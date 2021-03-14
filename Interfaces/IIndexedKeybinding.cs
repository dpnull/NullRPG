using Microsoft.Xna.Framework.Input;

namespace NullRPG.Interfaces
{
    public interface IIndexedKeybinding : IIndexable
    {
        int Index { get; set; }
        Keys Key { get; set; }
    }
}
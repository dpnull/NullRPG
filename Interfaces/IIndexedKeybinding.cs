using Microsoft.Xna.Framework.Input;

namespace NullRPG.Interfaces
{
    public interface IIndexedKeybinding
    {
        int Index { get; set; }
        Keys Keybinding { get; set; }
        IIndexable Object { get; set; }
    }
}
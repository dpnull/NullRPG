using Microsoft.Xna.Framework.Input;
using NullRPG.Input;

namespace NullRPG.Interfaces
{
    public interface IKeybinding
    {
        Keybinding.Keybindings Name { get; set; }
        Keybinding.Category CategoryType { get; set; }
        Keys Key { get; set; }
        bool IsVisible { get; set; }
    }
}
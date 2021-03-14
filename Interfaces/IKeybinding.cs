using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace NullRPG.Interfaces
{
    public interface IIndexable
    {
        int Index { get; set; }
        Keys Keybinding { get; set; }
        object Object { get; set; }
    }
}

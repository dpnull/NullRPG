using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Console = SadConsole.Console;
namespace NullRPG.Windows.Editor
{
    public class AddComponentWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public AddComponentWindow(int width, int height) : base(width, height)
        {

        }
    }
}

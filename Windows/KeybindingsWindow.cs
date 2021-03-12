using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using System.Linq;
using SadConsole.Input;
using NullRPG.Input;

namespace NullRPG.Windows
{
    public class KeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;
        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.KeybindingsX, Constants.Windows.KeybindingsY);

            Global.CurrentScreen.Children.Add(this);
        }

    }
}

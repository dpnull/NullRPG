using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class GameWindow : Console, IUserInterface
    {
        public GameWindow(int width, int height) : base(width, height)
        {
            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            // Print game title at the top
            Print((int)System.Math.Round((Width / 2) / 1.5f) - Constants.GameTitle.Length / 2, 1, Constants.GameTitle);

            Global.CurrentScreen = this;
        }

        public Console Console { get { return this; } }
    }
}

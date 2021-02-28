using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.Extensions;
using System;

namespace NullRPG.Windows
{
    public class GameWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public GameWindow(int width, int height) : base(width, height)
        {
            // print game title at the top
            ColoredString tStr = new ColoredString($"  {Constants.GameTitle}  ");
            tStr.SetForeground(Color.White);
            tStr.SetBackground(Color.DarkGreen);
            Print(Width / 8, 0, tStr);
            Print(Width - 20, 0, Constants.Build, Color.Gray);

            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            Global.CurrentScreen = this;
        }
    }
}

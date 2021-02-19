using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;

namespace NullRPG.Windows
{
    public class StatsWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public StatsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 10);

            PrintStats();

            Global.CurrentScreen.Children.Add(this);
        }

        public void PrintStats()
        {
            this.PrintInsideSeparators(1, "HP: 100 | LVL: 3 | XP: 100", true);
        }
    }
}

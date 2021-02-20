using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;

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
            Position = new Point(0, 0);

            PrintStats();

            Global.CurrentScreen.Children.Add(this);
        }

        public void PrintStats()
        {
            this.PrintInsideSeparators(1, "HP: 100 | LVL: 3 | XP: 100", true);
        }

        public void Update()
        {
            AutoHide();
        }

        // Automatically hide when Travel window is visible
        private void AutoHide()
        {
            if (UserInterfaceManager.Get<TravelWindow>().IsVisible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }
    }
}

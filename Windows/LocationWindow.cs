using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using NullRPG.GameObjects;

namespace NullRPG.Windows
{
    public class LocationWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        public LocationWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, Constants.Windows.StatsHeight);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            DrawLocation();

            base.Update(timeElapsed);
        }


        public void Update()
        {
            AutoHide();
        }

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

        private void DrawLocation()
        {
            Print(1, 1, "Location");
            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);
        }

    }
}

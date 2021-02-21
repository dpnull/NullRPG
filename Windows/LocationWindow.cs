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
using SadConsole.Effects;

namespace NullRPG.Windows
{
    public class LocationWindow : Console, IUserInterface
    {
        public Console Console { get { return this; } }

        public LocationWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.GameWidth - Constants.Windows.LocationWidth - 1, Constants.GameHeight - Constants.Windows.KeybindingsHeight - Constants.Windows.LocationHeight - 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            
            AutoHide();
            DrawLocation(Game.GameSession.Player);
            base.Update(timeElapsed);
            
        }

        private void AutoHide()
        {
            if (UserInterfaceManager.Get<TravelWindow>().IsVisible || UserInterfaceManager.Get<CharacterWindow>().IsVisible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void DrawLocation(Player player)
        {
            ColoredString locationName = new ColoredString($"{player.GetCurrentLocation().Name}");
            locationName.SetForeground(Color.Green);


            ColoredString locationDescription = new ColoredString($"{player.GetCurrentLocation().Description}");
            locationDescription.SetForeground(Color.White);

            Print(this.GetWindowXCenter() - (locationName.String.Length / 2), 0, locationName);
            this.PrintSeparator(1);

            Print(0, 2, locationDescription);
        }

    }
}

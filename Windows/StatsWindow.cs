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
    public class StatsWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public StatsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {       
            Clear();

            AutoHide();

            PrintStats(Game.GameSession.Player);

            base.Draw(timeElapsed);
        }

        public void PrintStats(Player player)
        {
            string stats = $"HP: {player.Health} / {player.MaxHealth}    Gold: {player.Gold}    Damage: {player.MinDmg} - {player.MaxDmg}    Defense: {player.Defense}";
            this.PrintInsideSeparators(1, stats, true);
        }

        // Automatically hide this console if any of the listed consoles are visible
        private void AutoHide()
        {
            if (UserInterfaceManager.Get<TravelWindow>().IsVisible || UserInterfaceManager.Get<CharacterWindow>().IsVisible
                || UserInterfaceManager.Get<InventoryWindow>().IsVisible)
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

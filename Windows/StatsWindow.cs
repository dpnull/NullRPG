using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Interfaces;
using SadConsole;
using System;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class StatsWindow : Console, IUserInterface
    {
        public Console Console => this;

        public StatsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            DrawStats(Game.GameSession.Player);

            Global.CurrentScreen.Children.Add(this); // add to game window
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawStats(Game.GameSession.Player);

            base.Draw(timeElapsed);
        }

        private void DrawStats(Player player)
        {
            if (player != null)
            {
                int _y = 0;
                string s = "    "; // separator of 4 spaces

                string drawable = $"{player.Name}{s}HP: {player.Health} / {player.MaxHealth}{s}Gold: {player.Gold}{s}Area: {player.CurrentArea.Name}";

                this.DrawSeparator(_y, "+", DefaultForeground); _y++;
                Print(this.GetWindowXCenter() - (drawable.Length / 2), _y, drawable); _y++;
                this.DrawSeparator(_y, "+", DefaultForeground);
            }
        }
    }
}
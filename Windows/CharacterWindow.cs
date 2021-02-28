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
using SadConsole.Input;

namespace NullRPG.Windows
{
    public class CharacterWindow : Console, IUserInterface
    {
        public Console Console => this;

        public CharacterWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            DrawDetailedStats(Game.GameSession.Player);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawDetailedStats(Game.GameSession.Player);

            base.Draw(timeElapsed);
        }

        private void DrawDetailedStats(Player player)
        {
            DrawExperience(player, 0, 0, Width);
        }

        private void DrawExperience(Player player, int x, int y, int width)
        {
            string bar = "[";

            double percent = (double)player.Experience / player.ExperienceNeeded;
            int complete = Convert.ToInt32(percent * width);
            // int incomplete = width - complete;

            for (int i = 0; i < complete; i++)
            {
                bar += "#";
            }

            for (int i = complete; i < width; i++)
            {
                bar += ".";
            }

            bar += "]";

            Print(x, y, bar);
            string printableExperience = $"EXP: {player.Experience} / {player.ExperienceNeeded}";
            Print(x + 1, this.GetWindowYCenter() - (printableExperience.Length / 2), printableExperience);
        }

    }
}

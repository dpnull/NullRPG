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
            Clear();

            DrawDetailedStats(Game.GameSession.Player);

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
            {
                Game.GameSession.Player.Experience += 1;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
            }

            return false;
        }

        private void DrawDetailedStats(Player player)
        {
            DrawExperience(player, 0, 3, Width);
            DrawCharacter(player);
        }

        private void DrawExperience(Player player, int x, int y, int width)
        {
            string bar = "[";

            double percent = (double)player.Experience / player.ExperienceNeeded;
            int complete = Convert.ToInt32(percent * width);
            //int incomplete = width - complete;

            for (int i = 0; i < complete; i++)
            {
                bar += "#";
            }

            for (int i = complete; i < width - 2; i++)
            {
                bar += ".";
            }

            bar += "]";

            Print(x, y, bar);
            string printableExperience = $"EXP: {player.Experience} / {player.ExperienceNeeded}";
            Print(this.GetWindowXCenter() - (printableExperience.Length / 2), y + 1, printableExperience);
        }

        private void DrawCharacter(Player player)
        {
            int _x = 1;
            int _y = 4;
            this.DrawHeader(0, $"{player.Name}'s character overview", "+", Color.Green); _y++;

            string level = $"Level: {player.Level}";
            string health = $"Health: {player.Health} / {player.MaxHealth}";
            string damage = $"Attack: {player.MinDmg} / {player.MaxDmg}";
            string gold = $"Gold: {player.Gold}";

            string weapon = $"Current weapon: {player.GetWeaponName()}";

            Print(_x, _y, level); _y++;
            Print(_x, _y, health); _y++;
            Print(_x, _y, damage); _y += 2;
            Print(_x, _y, gold); _y += 2;

            Print(_x, _y, weapon);
        }

    }
}

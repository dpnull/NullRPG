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
        public Console Console { get; set; }

        public CharacterWindow(int width, int height) : base(width, height)
        {
            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            PrintStats(Game.GameSession.Player);
            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                CloseStatsWindow();
                return true;
            }

            return false;
        }

        private void PrintStats(Player player)
        {
            this.PrintSeparator(0);
            string str = $"{player.Name}'s stats";
            Print(this.GetWindowXCenter() - (str.Length / 2), 1, str, Color.Green);
            this.PrintSeparator(2);
            Print(0, 3, $"Class: {player.CharacterClass}", Color.WhiteSmoke);
            Print(0, 4, $"HP: {player.Health} / {player.MaxHealth}");
            Print(0, 5, $"Level: {player.Level}");
            Print(0, 6, $"Experience: {player.Experience}");
            Print(0, 7, $"Current gold: {player.Gold}");
        }

        private void CloseStatsWindow()
        {
            this.Transition(UserInterfaceManager.Get<GameWindow>());
            UserInterfaceManager.Get<StatsWindow>().Update();
            UserInterfaceManager.Get<LocationWindow>().Update();
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
    }
}

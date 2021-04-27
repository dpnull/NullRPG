using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using static NullRPG.EntityComponents;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class CharacterWindow : Console, IUserInterface
    {
        public Console Console { get; }

        public CharacterWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawCharacter();

            base.Draw(timeElapsed);
        }

        public override void OnFocusLost()
        {
            base.OnFocusLost();
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<Windows.GameWindow>());

                return true;
            }

            return false;
        }

        private void DrawCharacter()
        {
            var player = EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId);
            var playerStats = player.GetComponent<EntityComponents.BaseStats>();

            this.DrawHeader(0, $"  {player.Name}'s character overview  ", Constants.Theme.HeaderForegroundColor, Constants.Theme.HeaderBackgroundColor);

            DrawStats(playerStats);
            DrawExperience(playerStats, 0, 2, Width);
        }

        private void DrawStats(BaseStats playerStats)
        {
            

            var level = $"Level: {playerStats.Level}";
            var health = $"Health: {playerStats.Health} - {playerStats.MaxHealth}";
            var defense = $"Defense: {playerStats.Defense}";
            var gold = $"Gold: {playerStats.Gold}";

            string[] printable = { level, health, defense, gold };
            int _x = 1;
            int _y = 4;
            foreach (var p in printable)
            {
                Print(_x, _y, p); _y++;
            }
        }

        private void DrawExperience(BaseStats playerStats, int x, int y, int width)
        {
            var experience = playerStats.Experience;
            var experienceRequired = playerStats.RequiredExperience;

            string bar = "[";

            double percent = (double)experience / experienceRequired;
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
            string printableExperience = $"EXP: {experience} / {experienceRequired}";
            Print(this.GetWindowXCenter() - (printableExperience.Length / 2), y + 1, printableExperience);
        }
    }
}
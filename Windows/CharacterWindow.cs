using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Navigation;
using SadConsole;
using SadConsole.Input;
using System;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class CharacterWindow : Console, IUserInterface
    {
        public CharacterWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            DrawDetailedStats();

            Global.CurrentScreen.Children.Add(this);
        }

        public Console Console => this;

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawDetailedStats();

            base.Draw(timeElapsed);
        }

        public override void OnFocusLost()
        {
            UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId = -1;
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (UserInterfaceManager.Get<CharacterKeybindingsWindow>().IndexedKeybindings != null) // IndexedKeybindings is created after this window becomes visible
            {
                foreach (var key in UserInterfaceManager.Get<CharacterKeybindingsWindow>().IndexedKeybindings.GetIndexedKeybindings())
                {
                    if (info.IsKeyPressed(key.Keybinding))
                    {
                        var itemPreviewWindow = UserInterfaceManager.Get<ItemPreviewWindow>();
                        itemPreviewWindow.
                            SetObjectForPreview(UserInterfaceManager.Get<CharacterKeybindingsWindow>().IndexedKeybindings.GetIndexable(key.Index).ObjectId);
                        return true;
                    }
                }
            }

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

        private void DrawCharacter(Player player)
        {
            this.DrawHeader(0, $"  {player.Name}'s character overview  ", Constants.Theme.HeaderForegroundColor, Constants.Theme.HeaderBackgroundColor);

            int _x = 1;
            int _y = 4;

            string level = $"Level: {player.Level}";
            string health = $"Health: {player.Health} / {player.MaxHealth}";
            string defense = $"Defense: {player.Defense}";
            string damage = $"Attack: {player.MinDmg} - {player.MaxDmg}";
            string gold = $"Gold: {player.Gold}";

            Print(_x, _y, level); _y++;
            Print(_x, _y, health); _y++;
            Print(_x, _y, defense); _y++;
            Print(_x, _y, damage); _y += 2;
            Print(_x, _y, gold); _y += 2;
        }

        private void DrawDetailedStats()
        {
            var player = EntityManager.Get<Player>(Game.GameSession.Player.ObjectId);
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
    }
}
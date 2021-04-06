using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Entity;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class CharacterWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public object AttributeManager { get; private set; }

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
            var player = EntityManager.Get<Player>(Game.GameSession.Player.ObjectId);

            var playerStats = player.GetComponent<EntityComponent>();

            var name = $"+ {player.Name}'s overview +";
            var health = $"Health: {playerStats.Health} - {playerStats.MaxHealth}";           
            var defense = $"Defense: {playerStats.Defense}";
            var gold = $"Gold: {playerStats.Gold}";

            string[] printable = { name, health, defense, gold };
            int _x = 1;
            int _y = 4;
            foreach(var p in printable)
            {
                Print(_x, _y, p); _y++;
            }
        }
    }
}
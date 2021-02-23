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
using NullRPG.ItemTypes;

namespace NullRPG.Windows
{
    public class CharacterWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        private bool _drawWeapon;

        public CharacterWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

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

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.View)))
            {
                if(_drawWeapon == false) { _drawWeapon = true; return true; }
                else if(_drawWeapon == true) { _drawWeapon = false; return true; }

            }

            return false;
        }

        public override void Update(TimeSpan timeElapsed)
        {
            Clear();

            AutoHide();

            base.Update(timeElapsed);
        }

        private void PrintStats(Player player)
        {
            var playerWeapon = player.Inventory.GetCurrentWeapon();
            #region
            // Temporary, veru ugly
            var coloredCurHp = new ColoredString(player.Health.ToString());
            coloredCurHp.SetForeground(Color.LightGreen);

            var coloredMaxHp = new ColoredString(player.MaxHealth.ToString());
            coloredMaxHp.SetForeground(Color.LightGreen);

            var coloredHp = new ColoredString("Health ");
            coloredHp.SetForeground(Color.White);

            var slashSeparator = new ColoredString(" / ");
            slashSeparator.SetForeground(Color.White);


            #endregion // colored hp

            string levelAndXp = $"Level: {player.Level} [{player.Experience} - {player.ExperiencedNeeded}]";
            coloredHp = coloredHp + coloredCurHp + slashSeparator + coloredMaxHp;
            string defense = $"Defense: {player.Defense}";
            string gold = $"Gold: {player.Gold}";
            string attackDamage = $"Attack damage: {player.MinDmg} - {player.MaxDmg}";

            string currentWeapon = $"Currently wielding {playerWeapon.Name.ToLower()}";

            this.PrintSeparator(0);
            string str = $"{player.Name}'s Character Stats";
            Print(this.GetWindowXCenter() - (str.Length / 2), 1, str, Color.Green);
            this.PrintSeparator(2);
            Print(0, 3, levelAndXp);
            Print(0, 4, coloredHp);
            Print(0, 5, defense);
            Print(0, 6, attackDamage);
            Print(0, 8, gold);
            Print(0, 10, currentWeapon);
            if (!_drawWeapon)
            {
                this.PrintButton(currentWeapon.Length + 2, 10, "View More", Keybindings.GetKeybindingChar(Keybindings.Type.View), Color.Green, false);
            } else
            {
                this.PrintButton(currentWeapon.Length + 2, 10, "Hide", Keybindings.GetKeybindingChar(Keybindings.Type.View), Color.Green, false);
            }


            DrawWeapon(playerWeapon);
        }

        private void DrawWeapon(WeaponItem playerWeapon)
        {
            if (_drawWeapon)
            {
                string description = playerWeapon.Description;
                string damage = $"[{playerWeapon.MinDmg} - {playerWeapon.MaxDmg}]";
                string value = $"Value: {playerWeapon.Gold}";

                Print(0, 11, description);
                Print(0, 12, damage);
                Print(0, 13, value);
            }
        }

        private void CloseStatsWindow()
        {
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }

        private void AutoHide()
        {
            if (UserInterfaceManager.Get<TravelWindow>().IsVisible || UserInterfaceManager.Get<LocationWindow>().IsVisible)
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

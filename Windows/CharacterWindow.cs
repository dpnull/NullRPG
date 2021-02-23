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

        internal static bool _drawWeapon;
        internal static bool _drawHeadItem;

        internal class ViewWindow : Console
        {
            private static readonly int ViewWidth = 40;
            private static readonly int ViewHeight = 10;
            public ViewWindow() : base(ViewWidth, ViewHeight)
            {
                Position = new Point(Constants.Windows.CharacterWidth - ViewWidth, (Constants.Windows.CharacterHeight - ViewHeight) / 2);

                IsVisible = true;
                IsFocused = false;
            }

            public override void Update(TimeSpan timeElapsed)
            {
                Clear();

                this.DrawBorders(Width, Height, "+", "|", "-", Color.White);

                AutoHide();
                DrawWeapon(Game.GameSession.Player.Inventory.GetCurrentWeapon());
                DrawHeadItem(Game.GameSession.Player.Inventory.GetCurrentHeadItem());
                base.Update(timeElapsed);
            }

            // TODO: automate and shrink drawing into one function
            private void DrawWeapon(WeaponItem playerWeapon)
            {
                if (_drawWeapon)
                {
                    IsVisible = true;

                    string name = $"- {playerWeapon.Name} -";
                    string description = playerWeapon.Description;
                    string damage = $"[{playerWeapon.MinDmg} - {playerWeapon.MaxDmg}]";
                    string value = $"Value: {playerWeapon.Gold}";

                    Print(2, 1, name);
                    Print(2, 2, description);
                    Print(2, 3, damage);
                    Print(2, 4, value);
                }

            }

            private void DrawHeadItem(HeadItem playerHeadItem)
            {
                if (_drawHeadItem)
                {
                    IsVisible = true;
                    string name = $"- {playerHeadItem.Name} -";
                    string description = playerHeadItem.Description;
                    string defense = $"Defense: {playerHeadItem.Defense}";
                    string value = $"Value: {playerHeadItem.Gold}";

                    Print(2, 1, name);
                    Print(2, 2, description);
                    Print(2, 3, defense);
                    Print(2, 4, value);
                }

            }

            private void AutoHide()
            {
                if(!_drawWeapon && !_drawWeapon)
                {
                    IsVisible = false;
                }
            }

        }


        public Console Console { get; set; }

        private ViewWindow _viewWindow;

        public CharacterWindow(int width, int height) : base(width, height)
        {
            _viewWindow = new ViewWindow();

            Position = new Point(0, 1);

            Children.Add(_viewWindow);
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
                _drawHeadItem = false;
                _drawWeapon = false;
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                _drawHeadItem = false;
                if(_drawWeapon == false) { _drawWeapon = true; return true; }
                else if(_drawWeapon == true) { _drawWeapon = false; return true; }

            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                _drawWeapon = false;
                if (_drawHeadItem == false) { _drawHeadItem = true; return true; }
                else if (_drawHeadItem == true) { _drawHeadItem = false; return true; }

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
            var playerHeadItem = player.Inventory.GetCurrentHeadItem();
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


            #endregion  // colored hp string

            string levelAndXp = $"Level: {player.Level} [{player.Experience} - {player.ExperiencedNeeded}]";
            coloredHp = coloredHp + coloredCurHp + slashSeparator + coloredMaxHp;
            string defense = $"Defense: {player.Defense}";
            string gold = $"Gold: {player.Gold}";
            string attackDamage = $"Attack damage: {player.MinDmg} - {player.MaxDmg}";

            // colored item strings
            var currentWeapon = new ColoredString  ($"[1] WEAPON    {playerWeapon.Name}");
            var currentHeadItem = new ColoredString($"[2] HEAD      {playerHeadItem.Name}");

            currentWeapon[1].Foreground = Color.Green;
            currentHeadItem[1].Foreground = Color.Green;


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
            Print(0, 11, currentHeadItem);
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

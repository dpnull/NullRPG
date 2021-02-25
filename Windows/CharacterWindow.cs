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
        // Character window 
        public Console Console { get; set; }

        public bool CanDrawWeapon { get; set; }
        public bool CanDrawHeadItem { get; set; }
        public bool CanDrawBodyItem { get; set; }
        public bool CanDrawLegsItem { get; set; }

        public CharacterWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            // welcome to the bool hell :^)
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                Game.WindowManager.CloseCurrentWindow(this);
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = null;
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = Game.GameSession.Player.Inventory.GetCurrentWeapon();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = Game.GameSession.Player.Inventory.GetCurrentHeadItem();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = Game.GameSession.Player.Inventory.GetCurrentBodyItem();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D4))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = Game.GameSession.Player.Inventory.GetCurrentLegsItem();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.U))
            {
                Game.GameSession.Player.Experience += 1;
                return true;
            }

            // todo: perhaps add optional close button

            return false;
        }

        private void DrawExperienceBar(int x, int y, int width, Player player)
        {
            string bar = "[";

            double percent = (double)player.Experience / player.ExperiencedNeeded;
            int complete = Convert.ToInt32(percent * width);
            int incomplete = width - complete;

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

        }

        public override void Update(TimeSpan timeElapsed)
        {
            AutoHide();

            Clear();

            DrawExperienceBar(0, 3, Width - 2, Game.GameSession.Player);

            DrawStats(Game.GameSession.Player);

            base.Update(timeElapsed);
        }

        private void DrawStats(Player player)
        {
            int x = 0;
            int y = 5;
            var playerWeapon = player.Inventory.GetCurrentWeapon();
            var playerHeadItem = player.Inventory.GetCurrentHeadItem();
            var playerBodyItem = player.Inventory.GetCurrentBodyItem();
            var playerLegsItem = player.Inventory.GetCurrentLegsItem();
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
            var currentWeapon = new ColoredString  ($"[1] WEAPON    {playerWeapon.Item.Name}");
            var currentHeadItem = new ColoredString($"[2] HEAD      {playerHeadItem.Item.Name}");
            var currentBodyItem = new ColoredString($"[3] BODY      {playerBodyItem.Item.Name}");
            var currentLegsItem = new ColoredString($"[4] LEGS      {playerLegsItem.Item.Name}");

            currentWeapon[1].Foreground = Color.Green;
            currentHeadItem[1].Foreground = Color.Green;
            currentBodyItem[1].Foreground = Color.Green;
            currentLegsItem[1].Foreground = Color.Green;


            this.PrintSeparator(0);
            string str = $"{player.Name}'s Character Stats";
            Print(this.GetWindowXCenter() - (str.Length / 2), 1, str, Color.Green);
            this.PrintSeparator(2);
            Print(this.GetWindowXCenter() - (levelAndXp.Length/2), y - 1, levelAndXp); y++;
            Print(6, y, coloredHp); y++;
            Print(6, y, defense); y++;
            Print(6, y, attackDamage); y++;
            Print(6, y, gold); y+=6;
            Print(0, y, currentWeapon); y++;
            Print(0, y, currentHeadItem); y++;
            Print(0, y, currentBodyItem); y++;
            Print(0, y, currentLegsItem); y++;
        }

        private void AutoHide()
        {
            if (UserInterfaceManager.Get<TravelWindow>().IsVisible || UserInterfaceManager.Get<LocationWindow>().IsVisible ||
                UserInterfaceManager.Get<InventoryWindow>().IsVisible)
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

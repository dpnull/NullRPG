using System;
using System.Collections.Generic;
using System.Text;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.GameObjects;
using Microsoft.Xna.Framework;
using SadConsole;
using NullRPG.Interfaces;

namespace NullRPG.Windows
{
    public class InventoryWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }


        public override void Update(TimeSpan timeElapsed)
        {
            DrawFilters();
            base.Update(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.All)))
            {
                ShowAll(Game.GameSession.Player);
                return true;
            }

            return false;
        }

        private void ShowAll(Player player)
        {
            var inventory = player.Inventory.GetInventory();
            int y = 1; int x = 1;
            foreach(var item in inventory)
            {
                string printable = $"{item.Name}    {item.Description}    {item.Gold}";
                Print(x, y, printable);
            }
        }

        private void DrawFilters()
        {
            int x = 1;
            int y = Constants.Windows.InventoryHeight - Constants.Windows.KeybindingsHeight - 2;
            var all = Keybindings.GetKeybindingObject(Keybindings.Type.All).TypeName.ToString();
            var eq = Keybindings.GetKeybindingObject(Keybindings.Type.Equipment).TypeName.ToString();
            var misc = Keybindings.GetKeybindingObject(Keybindings.Type.Miscellaneous).TypeName.ToString();
            this.PrintButton(x, y, all, Keybindings.GetKeybindingChar(Keybindings.Type.All), Color.Green, false);
            this.PrintButton(x, y - 1, eq, Keybindings.GetKeybindingChar(Keybindings.Type.Equipment), Color.Green, false);
            this.PrintButton(x, y - 2, misc, Keybindings.GetKeybindingChar(Keybindings.Type.Miscellaneous), Color.Green, false);
            //this.PrintButton(x + eq.Length + all.Length + spacing, 1, misc, Keybindings.GetKeybindingChar(Keybindings.Type.Miscellaneous), Color.Green, false);
        }
    }
}

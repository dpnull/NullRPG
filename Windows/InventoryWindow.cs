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
using NullRPG.ItemTypes;

namespace NullRPG.Windows
{
    public class InventoryWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        private Item[] Printable { get; set; }

        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }


        public override void Update(TimeSpan timeElapsed)
        {
            Draw();
            base.Update(timeElapsed);
        }

        private void Draw()
        {
            Clear();
            DrawInventory();
            DrawFilters();
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
                Printable = ShowAll(Game.GameSession.Player);
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Miscellaneous)))
            {
                Printable = ShowMisc(Game.GameSession.Player);
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Equipment)))
            {
                Printable = ShowEquipment(Game.GameSession.Player);
                return true;
            }

            return false;
        }

        private void DrawInventory()
        {
            if (Printable != null)
            {
                int y = 1; int x = 1;
                foreach (var item in Printable)
                {
                    string name = $"- {item.Name} -";
                    string value = $"Val: {item.Gold}";
                    Print(x, y, name);
                    Print(x + 25, y, value);
                    y++;
                }
            }
        }

        private Item[] ShowAll(Player player)
        {
            return player.Inventory.GetInventory();
        }

        private Item[] ShowMisc(Player player)
        {
            return player.Inventory.GetMisc();
        }

        private Item[] ShowEquipment(Player player)
        {
            return player.Inventory.GetEquipment();
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

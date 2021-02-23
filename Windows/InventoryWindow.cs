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
    class InventoryWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            DrawInventory(Game.GameSession.Player.Inventory);
            base.Update(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }

            return base.ProcessKeyboard(info);
        }

        private void DrawInventory(Inventory inventory)
        {
            int y = 0;
            foreach(var item in inventory.GetInventory())
            {
                string printable = $"- {item.Name} -    ATK: {item.MinDmg} - {item.MaxDmg}    Value: {item.Gold}";
                Print(0, y, printable);
            }
        }
    }
}

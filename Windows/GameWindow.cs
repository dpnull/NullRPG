using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = SadConsole.Console;
using SadConsole;
using SadConsole.Input;
using Microsoft.Xna.Framework;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Input;
using NullRPG.Extensions;

namespace NullRPG.Windows
{
    public class GameWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public GameWindow(int width, int height) : base(width, height)
        {
            // print game title at the top
            ColoredString tStr = new ColoredString($"  {Constants.GameTitle}  ");
            tStr.SetForeground(Constants.Theme.DefaultForeground);
            tStr.SetBackground(Color.Blue);
            Print(Width / 8, 0, tStr);
            Print(Width - 20, 0, Constants.GameBuildVersion, Color.Gray);

            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            Global.CurrentScreen = this;
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Inventory)))
            {
                OpenInventoryWindow();
                return true;
            }


            return false;
        }

        private void OpenInventoryWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<InventoryWindow>());
        }
    }
}

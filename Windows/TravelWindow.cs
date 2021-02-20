using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public TravelWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 0);

            PrintLocations();

            Global.CurrentScreen.Children.Add(this);
        }

        private void PrintLocations()
        {
            this.PrintInsideSeparators(this.GetWindowYCenter(), "It worked!", true);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                CloseTravelWindow();
                return true;
            }

            return false;
        }

        private void CloseTravelWindow()
        {
            this.Transition(UserInterfaceManager.Get<GameWindow>());
            UserInterfaceManager.Get<StatsWindow>().Update();
        }
    }
}

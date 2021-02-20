using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using System.Linq;

namespace NullRPG.Windows
{
    public class KeybindingsWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, Constants.GameHeight - height);

            // for testing purposes
            DefaultBackground = Color.DarkGray;

            PrintKeybindings();

            Global.CurrentScreen.Children.Add(this);
        }

        private void PrintKeybindings()
        {
            var keybindings = KeybindingsManager.GetKeybindings();

            int y = 0;
            foreach (var (name, binding) in keybindings)
            {
                this.PrintButton(0, y, name.ToString(), char.Parse(binding.ToString()), Color.DarkGreen, true);
                y++;
            }
        }
    }
}
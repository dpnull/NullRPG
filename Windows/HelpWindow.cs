using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using SadConsole;
using Console = SadConsole.Console;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using NullRPG.Managers;
using SadConsole.Controls;
using NullRPG.Extensions;
using SadConsole.Input;
using Microsoft.Xna.Framework;

namespace NullRPG.Windows
{
    public class HelpWindow : Console, IUserInterface
    {
        public Console Console => this;

        public HelpWindow(int width, int height) : base(width, height)
        {
            PrintConfirmation();
            DrawButtons();
        }

        private void PrintConfirmation()
        {
            this.PrintInsideSeparators(this.GetWindowYCenter(), "It works!", true, Color.Red);
        }

        private void DrawButtons()
        {
            this.PrintButton(this.GetWindowXCenter(), this.GetWindowYCenter() + 2, "Return", 'Q', Color.DarkGreen, true);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                Environment.Exit(0);
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Q))
            {
                OpenTitleWindow();
                return true;
            }

            return false;
        }

        private void OpenTitleWindow()
        {
            this.Transition(UserInterfaceManager.Get<TitleWindow>());
        }
    }
}

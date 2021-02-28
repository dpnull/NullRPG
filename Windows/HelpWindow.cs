using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Managers;
using SadConsole.Controls;
using NullRPG.Extensions;
using SadConsole.Input;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;

namespace NullRPG.Windows
{
    public class HelpWindow : Console, IUserInterface
    {
        private Button _backBtn;
        public Console Console => this;

        public HelpWindow(int width, int height) : base(width, height)
        {
            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();
            DrawConfirmation();
            DrawButtons();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(_backBtn.Key))
            {
                OpenTitleWindow();
            }

            return false;
        }

        private void DrawConfirmation()
        {
            this.DrawRectangleTitled(0, 0, Width - 2, Height - 10, "+", "-", "|", "|", new ColoredString("IT WORKS"));
        }

        private void DrawButtons()
        {
            _backBtn = new Button("Back", Microsoft.Xna.Framework.Input.Keys.D1, Color.Green, DefaultForeground);
            _backBtn.DrawNumericOnly(true);
            _backBtn.Draw(this, this.GetWindowXCenter() - (_backBtn.Length / 2), this.GetWindowYCenter());
        }

        private void OpenTitleWindow()
        {
            this.FullTransition(UserInterfaceManager.Get<TitleWindow>());
        }
    }
}

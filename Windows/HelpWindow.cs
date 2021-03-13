﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class HelpWindow : Console, IUserInterface
    {
        private ButtonString _backBtn;
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
            this.DrawRectangleTitled(0, 0, Width - 2, Height - 10, "+", "-", "|", "|", new ColoredString("IT WORKS"), true);
        }

        private void DrawButtons()
        {
            _backBtn = new ButtonString(new ColoredString("Back"), Microsoft.Xna.Framework.Input.Keys.D1, Color.Green, DefaultForeground, 0, 0, true);
            _backBtn.Draw(this.GetWindowXCenter() - (_backBtn.GetLength() / 2), this.GetWindowYCenter(), this);
        }

        private void OpenTitleWindow()
        {
            this.FullTransition(UserInterfaceManager.Get<TitleWindow>());
        }
    }
}
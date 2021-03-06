﻿using Microsoft.Xna.Framework;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Navigation;
using SadConsole;
using System;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class KeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;

        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.KeybindingsX, Constants.Windows.KeybindingsY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            var generalKeybindings = UserInterfaceManager.Get<GeneralKeybindingsWindow>();

            generalKeybindings.Draw();

            var locationKeybindings = UserInterfaceManager.Get<LocationKeybindingsWindow>();

            locationKeybindings.Draw();

            base.Draw(timeElapsed);
        }
    }
}
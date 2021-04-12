﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Components.Item;
using NullRPG.GameObjects.Entity;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using static NullRPG.Input.Keybinding;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        public Console Console { get; }

        public TravelWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.TravelX, Constants.Windows.TravelY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
                return true;
            }

            return false;
        }

        public override void Draw(TimeSpan timeElapsed)
        {

            DrawAvailableLocations();

            base.Draw(timeElapsed);
        }

        private void DrawAvailableLocations()
        {
            this.DrawHeader(0, "Travel to an area...", DefaultForeground, DefaultBackground);

            int y = 0;
            while(y < 10)
            {
                Print(0, y, "TESTETEWTWET");
                y++;
            }
        }
    }
}

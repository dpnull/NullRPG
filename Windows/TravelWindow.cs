﻿using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.GameObjects;

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

            DrawLocations(Game.GameSession.World);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            base.Update(timeElapsed);
        }

        private void DrawLocations(World world)
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
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }
    }
}

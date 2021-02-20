﻿using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.Extensions;

namespace NullRPG.Windows
{
    public class GameWindow : Console, IUserInterface
    {
        public Console Console { get { return this; } }

        public GameWindow(int width, int height) : base(width, height)
        {
            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            // Print game title at the top
            Print((int)System.Math.Round((Width / 2) / 1.5f) - Constants.GameTitle.Length / 2, 1, Constants.GameTitle);

            Global.CurrentScreen = this;
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(KeybindingsManager.GetKeybinding(Keybindings.Travel)))
            {
                OpenTravelWindow();
                return true;
            }

            return false;
        }

        private void OpenTravelWindow()
        {
            UserInterfaceManager.Get<TravelWindow>().ShowAndFocus();
            
            UserInterfaceManager.Get<StatsWindow>().Update(); // [Temporary]
        }


        
    }
}

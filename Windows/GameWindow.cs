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

            Global.CurrentScreen = this;
        }

        public override void Update(TimeSpan timeElapsed)
        {
            base.Update(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Travel)))
            {
                OpenTravelWindow();
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Character)))
            {
                OpenCharacterWindow();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.P))
            {
                Game.GameSession.Player.AddGold(1);
                return true;
            }

            return false;
        }

        private void OpenTravelWindow()
        {
            UserInterfaceManager.Get<TravelWindow>().ShowAndFocus();
        }
        
        private void OpenCharacterWindow()
        {
            UserInterfaceManager.Get<CharacterWindow>().ShowAndFocus();
        }


        
    }
}

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
            this.PrintInsideSeparators(0, "TRAVEL", true, Color.LightGreen);

            int y = 3;
            foreach(Location location in world.GetLocations())
            {
                Print(0, y, location.Name);
                y++;
            }
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

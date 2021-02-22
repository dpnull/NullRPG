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
using SadConsole.Controls;
using SadConsole.Themes;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        readonly IndexedKeybindings IndexedKeybindings;
        public Console Console
        {
            get { return this; }
        }

        public TravelWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            IndexedKeybindings = new IndexedKeybindings(Game.GameSession.World);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            DrawLocations(Game.GameSession.World);
            base.Update(timeElapsed);
        }

        private void DrawLocations(World world)
        {
            for (int i = 0; i < world.GetLocations().Length; i++)
            {
                this.PrintButton(0, i, world.GetLocations()[i].Name, char.Parse(IndexedKeybindings._indexedTravelKeybindings[i].Index.ToString()), Color.Green, false);
            }
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                CloseTravelWindow();
                return true;
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(1).Keybinding))
            {
                Travel(IndexedKeybindings.GetTravelKeybinding(1).Location);
                return true;
            }
            
            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(2).Keybinding))
            {
                Travel(IndexedKeybindings.GetTravelKeybinding(2).Location);
                return true;
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(3).Keybinding))
            {
                Travel(IndexedKeybindings.GetTravelKeybinding(3).Location);
                return true;
            }

            return false;
        }

        private void Travel(Location loc)
        {
            Game.GameSession.Player.TravelToLocation(loc);
            CloseTravelWindow();
        }

        private void CloseTravelWindow()
        {
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }
    }


}

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
            Clear();

            DrawLocations(Game.GameSession.World);
            base.Update(timeElapsed);
        }

        private void DrawLocations(World world)
        {
            for (int i = 0; i < world.GetLocations().Length; i++)
            {
                this.PrintInsideSeparators(1, "Travelling to...", true);
                this.PrintButton(1, i + 3, world.GetLocations()[i].Name, IndexedKeybindings._indexedTravelKeybindings[i].Index.ToString(), Color.Green, false);
            }
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }
            
            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(1)))
            {
                Game.CommandManager.Travel(IndexedKeybindings.GetIndexedLocation(1));
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }
            
            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(2)))
            {
                Game.CommandManager.Travel(IndexedKeybindings.GetIndexedLocation(2));
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(3)))
            {
                Game.CommandManager.Travel(IndexedKeybindings.GetIndexedLocation(3));
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(4)))
            {
                Game.CommandManager.Travel(IndexedKeybindings.GetIndexedLocation(4));
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }


            if (info.IsKeyPressed(IndexedKeybindings.GetTravelKeybinding(5)))
            {
                Game.CommandManager.Travel(IndexedKeybindings.GetIndexedLocation(5));
                Game.WindowManager.CloseCurrentWindow(this);
                return true;
            }

            return false;
        }
    }
}

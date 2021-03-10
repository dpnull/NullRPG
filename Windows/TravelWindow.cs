using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using NullRPG.GameObjects;
using SadConsole.Input;
using NullRPG.ItemTypes;
using NullRPG.Input;
using static NullRPG.Windows.InventoryWindow;
using NullRPG.GameObjects.Worlds;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        public Console Console => this;
        private IndexedKeybindings IndexedKeybindings;

        public TravelWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);


            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawLocations();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
            }

            return false;
        }

        private void DrawLocations()
        {
            this.DrawHeader(0, "Travel to area", "+", DefaultForeground);

            var areas = WorldManager.GetWorldAreas<Overworld>();
            // Initialize keybindings.
            List<IIndexable> bindable = new List<IIndexable>();
            // Todo: add checks if player's level is high enough. (not here)
            // Todo: automate the foreach loop for initializing keybindings?
            foreach (var area in areas)
            {
                if (area != null)
                {
                    bindable.Add((IIndexable)area);
                }
            }
            // Todo: automate this too?
            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings.GetIndexedKeybindings(), PrintContainerBase.ListType.Areas);
            printable.SetPrintingOffsets(0, 4, 30);

            printable.Print(this);

            /*
            int _x = 0;
            int _y = 3;

            foreach(var area in world.Areas)
            {
                Print(_x, _y++, $"areaId_{area.Key} | {area.Value.ObjectId} Area name: {area.Value.Name}");
                foreach(var loc in area.Value.Locations)
                {
                    Print(_x, _y++, $"{loc.Value.ObjectId} {loc.Value.Name}");
                }
            }

            /*
            foreach(var area in areas)
            {
                foreach (var loc in area.Locations)
                {
                    
                    Print(_x, _y++, $"areaId_{loc.Key} | Area name: {area.Name} | locId_{loc.Value.ObjectId} | Loc name: {loc.Value.Name} | lvl: {loc.Value.Level}");
                }
            }*/
        }
    }
}

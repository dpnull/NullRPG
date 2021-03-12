﻿using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using System.Linq;
using SadConsole.Input;
using NullRPG.Input;
using NullRPG.GameObjects.Worlds;

namespace NullRPG.Windows.Navigation
{
    public class LocationKeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;
        public IndexedKeybindings IndexedKeybindings { get; private set; }
        public LocationKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.LocationKeybindingsX, Constants.Windows.LocationKeybindingsY);

            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
        }

        public void Draw()
        {
            Clear();

            DrawKeybindings();
        }

        private void DrawKeybindings()
        {
            this.DrawSeparator(0, "-", DefaultForeground);

            var locations = WorldManager.GetWorldAreaLocations<Overworld>(Game.GameSession.Player.CurrentArea);

            List<IIndexable> bindable = new List<IIndexable>();

            foreach(var location in locations)
            {
                if (location != null)
                {
                    bindable.Add((IIndexable)location);
                }
            }

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings.GetIndexedKeybindings(), PrintContainerBase.ListType.Locations);
            printable.SetPrintingOffsets(1, 1, 30);

            printable.Print(this);

            this.DrawSeparator(Height - 1, "-", DefaultForeground);
        }
    }
}

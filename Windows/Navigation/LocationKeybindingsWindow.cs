﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.GameObjects.Worlds;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Navigation
{
    public class LocationKeybindingsWindow : BaseKeybindingsWindow, IUserInterface
    {
        public new Console Console => this;
        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }

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

            foreach (var location in locations)
            {
                if (location != null)
                {
                    bindable.Add((IIndexable)location);
                }
            }

            IndexedKeybindings = IndexedKeybindingsManager.CreateIndexedKeybindings<IIndexedKeybinding>(bindable);
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings, PrintContainerBase.ListType.Locations);
            printable.SetPrintingOffsets(1, 1, Width - 10);

            printable.Print(this);

            this.DrawSeparator(Height - 1, "-", DefaultForeground);
        }
    }
}
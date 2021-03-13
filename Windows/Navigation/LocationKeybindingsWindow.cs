using Microsoft.Xna.Framework;
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
        public new IndexedKeybindings IndexedKeybindings { get; private set; }

        public LocationKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.LocationKeybindingsX, Constants.Windows.LocationKeybindingsY);

            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
        }

        public void Draw()
        {
            Clear();

            DrawNewKeybindings();

            DrawKeybindings();
        }


        private void DrawNewKeybindings()
        {
            dynamic[] locations = GetDrawableKeybindingsObjects<IDrawableKeybinding>(WorldManager.GetWorldAreaLocations<Overworld>(Game.GameSession.Player.CurrentArea));
            // MERGE BELOW WITH ABOVE?
            List<IIndexable> bindable = new List<IIndexable>();

            foreach (var location in locations)
            {
                if (location != null)
                {
                    bindable.Add((IIndexable)location);
                }
            }

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings.GetIndexedKeybindings(), PrintContainerBase.ListType.Locations);
            printable.SetPrintingOffsets(1, 1, Width - 10);

            printable.Print(this);

            this.DrawSeparator(Height - 1, "-", DefaultForeground);
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

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings.GetIndexedKeybindings(), PrintContainerBase.ListType.Locations);
            printable.SetPrintingOffsets(1, 1, Width - 10);

            printable.Print(this);

            this.DrawSeparator(Height - 1, "-", DefaultForeground);
        }
    }
}
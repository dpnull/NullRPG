using Microsoft.Xna.Framework;
using NullRPG.Draw;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Navigation
{
    public class LocationKeybindingsWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }
        public List<ButtonString> Buttons { get; set; }
        public LocationKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.Keybindings.LocationX, Constants.Windows.Keybindings.LocationY);

            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
            
        }

        public void Draw()
        {
            Clear();

            DrawTravelKeybindings();
        }

        private void DrawTravelKeybindings()
        {
            this.DrawSeparator(0, "-", DefaultForeground);

            List<IIndexable> bindable = new List<IIndexable>();

            var area = EntityManager.GetEntityArea<IEntity>(Game.GameSession.Player);
            var locations = area.Locations.Values; //temp

            foreach(var location in locations)
            {
                if (location != null)
                {
                    bindable.Add(location);
                }
            }

            IndexedKeybindings = IndexedKeybindingsManager.CreateIndexedKeybindings<IIndexedKeybinding>(bindable);

            PrintContainerLocations printable = new PrintContainerLocations(area, IndexedKeybindings);

            printable.Draw(this, 1);
        }

    }
}

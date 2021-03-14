using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        public Console Console => this;
        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }

        public TravelWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawAreas();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            foreach (var keybinding in IndexedKeybindings)
            {
                if (info.IsKeyPressed(keybinding.Key))
                {
                    var player = EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId); // Todo: make gamesession player less accessible
                    EntityManager.TravelEntityToArea((Player)player, keybinding.ObjectId);
                    return true;
                }
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
            }

            return false;
        }

        private void DrawAreas()
        {
            this.DrawHeader(0, $"  Explore the areas around you  ", Constants.Theme.HeaderForegroundColor, Constants.Theme.HeaderBackgroundColor);

            var areas = WorldManager.GetWorldAreas<IArea>(Game.GameSession.Player.CurrentWorld.Name);
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
            IndexedKeybindings = IndexedKeybindingsManager.CreateIndexedKeybindings<IIndexedKeybinding>(bindable);
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings, PrintContainerBase.ListType.Areas);
            printable.SetPrintingOffsets(0, 4, 15);

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
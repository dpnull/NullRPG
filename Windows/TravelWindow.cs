﻿using Microsoft.Xna.Framework;
using NullRPG.Draw;
using NullRPG.Extensions;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Components.Item;
using NullRPG.GameObjects.Entity;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using static NullRPG.Input.Keybinding;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }

        public TravelWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.TravelX, Constants.Windows.TravelY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            foreach (var keybinding in IndexedKeybindings)
            {
                if (info.IsKeyPressed(keybinding.Key))
                {
                    EntityManager.ChangeEntityPosition(Game.GameSession.Player, EntityManager.PositionTypes.Area, keybinding.ObjectId);
                    MessageManager.AddColoredMessage(new ColoredString("Pressed"));
                    return true;
                }
            }
            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
                return true;
            }

            return false;
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawAvailableLocations();

            base.Draw(timeElapsed);
        }

        private void DrawAvailableLocations()
        {
            this.DrawHeader(0, "Travel to an area...", DefaultForeground, DefaultBackground);

            var world = EntityManager.GetEntityWorld(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId));
            var areas = AreaManager.GetWorldAreas(world);

            List<IIndexable> bindable = new();
            foreach(var area in areas)
            {
                bindable.Add(area);
            }

            IndexedKeybindings = IndexedKeybindingsManager.CreateIndexedKeybindings<IIndexedKeybinding>(bindable);
            PrintContainerTravel printable = new PrintContainerTravel(world, IndexedKeybindings);

            printable.Draw(this, 4);

        }
    }
}

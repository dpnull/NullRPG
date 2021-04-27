using Microsoft.Xna.Framework;
using NullRPG.Draw;
using NullRPG.Extensions;
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
                    EntityManager.ChangeEntityPosition(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId), Enums.PositionTypes.Area, keybinding.ObjectId);
                    MessageManager.AddColoredMessage(new ColoredString("Pressed"));
                    this.FullTransition(UserInterfaceManager.Get<GameWindow>());
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

            var world = WorldManager.GetWorld<IWorld>(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId)
                .GetComponent<EntityComponents.Position>().World.ObjectId);
            var areas = world.Areas.Values;
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

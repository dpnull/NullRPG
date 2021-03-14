using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Navigation;
using SadConsole;
using SadConsole.Input;
using System;
using static NullRPG.Input.Keybinding;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class GameWindow : Console, IUserInterface
    {
        public Console Console
        {
            get { return this; }
        }

        public GameWindow(int width, int height) : base(width, height)
        {
            // print game title at the top
            ColoredString tStr = new ColoredString($"  {Constants.GameTitle}  ");
            tStr.SetForeground(Color.White);
            tStr.SetBackground(Color.DarkGreen);
            Print(Width / 8, 0, tStr);
            Print(Width - 20, 0, Constants.Build, Color.Gray);

            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            Global.CurrentScreen = this;
        }

        public override void Update(TimeSpan timeElapsed)
        {
            UpdateKeybindingVisibility();

            base.Update(timeElapsed);
        }

        private void UpdateKeybindingVisibility()
        {
            KeybindingManager.UpdateVisibility(Keybindings.Chop, WorldObjectManager.ContainsWorldObject(Game.GameSession.Player.CurrentLocation,
                GameObjects.WorldObjectBase.Objects.Tree) && this.IsFocused);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            // TODO: SOMETIMES THROWS NULL REFERENCE
            if (UserInterfaceManager.Get<LocationKeybindingsWindow>().IndexedKeybindings != null)
            {
                foreach (var keybinding in UserInterfaceManager.Get<LocationKeybindingsWindow>().IndexedKeybindings)
                {
                    if (info.IsKeyPressed(keybinding.Key))
                    {
                        EntityManager.TravelEntityToLocation(Game.GameSession.Player, keybinding.ObjectId);
                        return true;
                    }
                }
            }


            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Character)))
            {
                OpenCharacterWindow();
                return true;
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Inventory)))
            {
                OpenInventoryWindow();
                return true;
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Travel)))
            {
                OpenTravelWindow();
                return true;
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Chop)))
            {
                OpenChoppingWindow();
            }

            return false;
        }

        private void OpenCharacterWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<CharacterWindow>());
        }

        private void OpenInventoryWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<InventoryWindow>());
        }

        private void OpenTravelWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<TravelWindow>());
        }

        private void OpenChoppingWindow()
        {
            var player = EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId);
            if (WorldObjectManager.ContainsWorldObject<ILocation>(player.CurrentLocation, GameObjects.WorldObjectBase.Objects.Tree))
            {
                this.SwitchFocusMakeVisible(UserInterfaceManager.Get<ChoppingWindow>());
            }
        }
    }
}
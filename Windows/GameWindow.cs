using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Actions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Navigation;
using SadConsole;
using SadConsole.Input;
using System;
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
            tStr.SetForeground(Constants.Theme.DefaultForeground);
            tStr.SetBackground(Color.Blue);
            Print(Width / 8, 0, tStr);
            Print(Width - 20, 0, Constants.GameBuildVersion, Color.Gray);

            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            Global.CurrentScreen = this;
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId) != null)
            {
                if(UserInterfaceManager.Get<LocationKeybindingsWindow>().IndexedKeybindings != null)
                {
                    foreach (var keybinding in UserInterfaceManager.Get<LocationKeybindingsWindow>().IndexedKeybindings)
                    {
                        if (info.IsKeyPressed(keybinding.Key))
                        {
                            EntityManager.ChangeEntityPosition<IEntity>(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId), Enums.PositionTypes.Location, keybinding.ObjectId);
                        }
                    }
                }

            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Inventory)))
            {
                OpenInventoryWindow();
                return true;
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Character)))
            {
                OpenCharacterWindow();
                return true;
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Travel)))
            {
                OpenTravelWindow();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.U))
            {
                var chopAction = new ActionChop(Game.GameSession.Player.GetComponent<EntityComponents.Position>().Location, Game.GameSession.Player);
                chopAction.OnInteract();
            }

            return false;
        }

        private void OpenInventoryWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<InventoryWindow>());
        }

        private void OpenCharacterWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<CharacterWindow>());
        }

        private void OpenTravelWindow()
        {
            this.SwitchFocusMakeVisible(UserInterfaceManager.Get<TravelWindow>());
        }
    }
}
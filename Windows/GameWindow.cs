using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.Extensions;
using System;
using NullRPG.Windows.Navigation;
using NullRPG.GameObjects;
using NullRPG.Input;

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
            base.Update(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            foreach (var key in UserInterfaceManager.Get<LocationKeybindingsWindow>().IndexedKeybindings.GetIndexedKeybindings())
            {
                if (info.IsKeyPressed(key.Keybinding))
                {
                    EntityManager.TravelEntityToLocation(Game.GameSession.Player, key.Object.ObjectId);
                    return true;
                }
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Character)))
            {
                OpenCharacterWindow();
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Inventory)))
            {
                OpenInventoryWindow();
                return true;
            }


            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Travel)))
            {
                OpenTravelWindow();
                return true;
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
    }
}

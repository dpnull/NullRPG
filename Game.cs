using NullRPG.Windows;
using NullRPG.Managers;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Interfaces;

namespace NullRPG
{
    class Game
    {
        public static TitleWindow TitleWindow { get; private set; }

        private static void Main()
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(Constants.GameWidth, Constants.GameHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;
            // Hook the update event so we can check for key presses.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime gameTime)
        {

        }

        public static void Reset()
        {
            UserInterfaceManager.IsInitialized = false;


            // perhaps add window exceptions
            foreach (var window in UserInterfaceManager.GetAll<IUserInterface>())
            {
                UserInterfaceManager.Remove(window);
            }
        }

        private static void Init()
        {
            Keybindings.CreateKeybindings();
            UserInterfaceManager.Initialize();

            // Shows the main menu
            TitleWindow = TitleWindow.Show();

            Global.CurrentScreen.IsFocused = true;
        }
    }

}

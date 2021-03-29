using Microsoft.Xna.Framework;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows;
using SadConsole;

namespace NullRPG
{
    class Game
    {
        public static MainMenuWindow MainMenuWindow { get; private set; }
        public static GameSession GameSession { get; set; }
        private static void Main()
        {
            SadConsole.Settings.ResizeMode = Settings.WindowResizeOptions.Stretch;

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
            GameSession = new GameSession();

            MainMenuWindow = MainMenuWindow.Show();

            Global.CurrentScreen.IsFocused = true;
        }
    }
}

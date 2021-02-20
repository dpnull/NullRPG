using System;
using NullRPG.Windows;
using SadConsole;
using Microsoft.Xna.Framework;
using Console = SadConsole.Console;
using NullRPG.Managers;

namespace NullRPG
{
    public static class Game
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

        private static void Init()
        {
            KeybindingsManager.InitializeKeybindings();
            UserInterfaceManager.Initialize();


            // Shows the main menu
            TitleWindow = TitleWindow.Show();

            Global.CurrentScreen.IsFocused = true;
        }

    }
}

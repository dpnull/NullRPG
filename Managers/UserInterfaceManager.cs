using NullRPG.Interfaces;
using NullRPG.Windows;
using NullRPG.Windows.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Managers
{
    public static class UserInterfaceManager
    {
        private static readonly List<IUserInterface> Interfaces = new List<IUserInterface>();

        public static bool IsPaused { get; set; }
        public static bool IsInitialized { get; set; }

        /// <summary>
        /// Instantiate windows upon launch.
        /// </summary>

        public static void Initialize()
        {
            var gameWindow = new Windows.GameWindow(Constants.Windows.GameWindowWidth, Constants.Windows.GameWindowHeight);
            Add(gameWindow);

            // Initialize last so all consoles are instantiated prior to creating keybinding bools for visibility
            var keybindingsWindow = new KeybindingsWindow(Constants.Windows.KeybindingsWidth, Constants.Windows.KeybindingsHeight);
            Add(keybindingsWindow);

            var inventoryWindow = new InventoryWindow(Constants.Windows.InventoryWidth, Constants.Windows.InventoryHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(inventoryWindow);

            var itemPreviewWindow = new ItemPreviewWindow(Constants.Windows.ItemPreviewWidth, Constants.Windows.ItemPreviewHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(itemPreviewWindow);

            var characterWindow = new CharacterWindow(Constants.Windows.CharacterWidth, Constants.Windows.CharacterHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(characterWindow);

            var generalKeybindingsWindow = new GeneralKeybindingsWindow(Constants.Windows.Keybindings.GeneralWidth, Constants.Windows.Keybindings.GeneralHeight);
            Add(generalKeybindingsWindow);

            var messageWindow = new MessageWindow(Constants.Windows.MessageWidth, Constants.Windows.MessageHeight);
            Add(messageWindow);

            var statWindow = new StatWindow(Constants.Windows.StatWidth, Constants.Windows.StatHeight);
            Add(statWindow);
        }

        /// <summary>
        /// Adds a window to the list of user interfaces.
        /// </summary>
        /// <typeparam name="T">The type of the window.</typeparam>
        /// <param name="userInterface">The window to add.</param>
        public static void Add<T>(T userInterface) where T : IUserInterface
        {
            Interfaces.Add(userInterface);
        }

        /// <summary>
        /// Gets a user interface window from the list of interfaces.
        /// </summary>
        /// <typeparam name="T">The type of the window.</typeparam>
        /// <returns>Returns the user interface window.</returns>
        public static T Get<T>() where T : IUserInterface
        {
            return Interfaces.OfType<T>().SingleOrDefault();
        }

        /// <summary>
        /// Returns an array of user interfaces.
        /// </summary>
        /// <typeparam name="T">The type of the window.</typeparam>
        public static IEnumerable<T> GetAll<T>()
        {
            return Interfaces.OfType<T>().ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="userInterface"></param>
        public static void Remove<T>(T userInterface) where T : IUserInterface
        {
            Interfaces.Remove(userInterface);
        }
    }
}
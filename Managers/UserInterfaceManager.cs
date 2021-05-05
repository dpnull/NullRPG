using NullRPG.Interfaces;
using NullRPG.Windows;
using NullRPG.Windows.Actions;
using NullRPG.Windows.Editor;
using NullRPG.Windows.Editor.ItemEditor;
using NullRPG.Windows.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Managers
{
    public static class UserInterfaceManager
    {
        private static readonly List<IUserInterface> Interfaces = new List<IUserInterface>();

        public static bool IsPaused { get; set; }
        public static bool IsInitialized { get; set; } = false;

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

            var statWindow = new StatWindow(Constants.Windows.StatWidth, Constants.Windows.StatHeight);
            Add(statWindow);

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

            var locationKeybindingsWindow = new LocationKeybindingsWindow(Constants.Windows.Keybindings.LocationWidth, Constants.Windows.Keybindings.LocationHeight);
            Add(locationKeybindingsWindow);

            var messageWindow = new MessageWindow(Constants.Windows.MessageWidth, Constants.Windows.MessageHeight);
            Add(messageWindow);

            var travelWindow = new TravelWindow(Constants.Windows.TravelWidth, Constants.Windows.TravelHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(travelWindow);

            var chopWindow = new ChopWindow(Constants.Windows.Actions.ChopWidth, Constants.Windows.Actions.ChopHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(chopWindow);

            // temporary

            var editorWindow = new MainEditorWindow(Constants.GameWidth, Constants.GameHeight);
            Add(editorWindow);

            var itemCreateWindow = new ItemCreateWindow(Constants.GameWidth, Constants.GameHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(itemCreateWindow);

            IsInitialized = true;
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

        public static void AutoVisibility()
        {
            CheckVisibility(Get<StatWindow>(), Get<GameWindow>().IsFocused);
            CheckVisibility(Get<LocationKeybindingsWindow>(), Get<GameWindow>().IsFocused);
        }

        /// <summary>
        /// Sets visibility for the window based on the criteria.
        /// </summary>
        /// <param name="window">The target window.</param>
        /// <param name="criteria">Criteria for visibility.</param>
        private static void CheckVisibility(SadConsole.Console window, bool criteria)
        {
            if(window != null)
            {
                if (criteria)
                {
                    window.IsVisible = true;
                }
                else if (!criteria)
                {
                    window.IsVisible = false;
                }
            }

        }
    }
}
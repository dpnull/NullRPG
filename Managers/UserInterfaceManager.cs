using NullRPG.Interfaces;
using System.Collections.Generic;
using NullRPG.Windows;
using System.Linq;
using System;

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
            var gameWindow = new GameWindow(Constants.GameWidth, Constants.GameHeight)
            {
                IsFocused = true,
                IsVisible = true
            };

            Add(gameWindow);

            var characterWindow = new CharacterWindow(Constants.Windows.CharacterWidth, Constants.Windows.CharacterHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(characterWindow);

            var statsWindow = new StatsWindow(Constants.Windows.StatsWidth, Constants.Windows.StatsHeight);
            Add(statsWindow);

            var inventoryWindow = new InventoryWindow(Constants.Windows.InventoryWidth, Constants.Windows.InventoryHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(inventoryWindow);


            var previewWindow = new ItemPreviewWindow(Constants.Windows.ItemPreviewWidth, Constants.Windows.ItemPreviewHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(previewWindow);

            var travelWindow = new TravelWindow(Constants.Windows.TravelWidth, Constants.Windows.TravelHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(travelWindow);

            var messageWindow = new MessageWindow(Constants.Windows.MessageWidth, Constants.Windows.MessageHeight);
            Add(messageWindow);

            // Initialize last so all consoles are instantiated prior to creating keybinding bools for visibility
            var keybindingsWindow = new KeybindingsWindow(Constants.Windows.KeybindingsWidth, Constants.Windows.KeybindingsHeight);
            Add(keybindingsWindow);

            IsInitialized = true;
        }

        /// <summary>
        /// Handles visibility of target window based on visibility of other windows
        /// </summary>
        public static void AutoVisiblity()
        {
            CheckVisibility(Get<StatsWindow>(), Get<CharacterWindow>().IsVisible || Get<InventoryWindow>().IsVisible ||
                Get<TravelWindow>().IsVisible);
        }

        /// <summary>
        /// Sets visibility for the window based on the criteria.
        /// </summary>
        /// <param name="window">The target window.</param>
        /// <param name="criteria">Criteria for visibility.</param>
        private static void CheckVisibility(IUserInterface window, bool criteria)
        {
            if (criteria)
            {
                window.Console.IsVisible = false;
            } else
            {
                window.Console.IsVisible = true;
            }
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

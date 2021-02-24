using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using NullRPG.Windows;
using System.Linq;

namespace NullRPG.Managers
{
    public static class UserInterfaceManager
    {
        private static readonly List<IUserInterface> Interfaces = new List<IUserInterface>();

        public static bool IsPaused { get; set; }
        public static bool IsInitialized { get; set; }

        // Initialize all windows
        public static void Initialize()
        {
            var gameWindow = new GameWindow(Constants.GameWidth, Constants.GameHeight);
            Add(gameWindow);

            var travelWindow = new TravelWindow(Constants.Windows.TravelWidth, Constants.Windows.TravelHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(travelWindow);

            var statsWindow = new StatsWindow(Constants.Windows.StatsWidth, Constants.Windows.StatsHeight);
            Add(statsWindow);

            var titleWindow = new TitleWindow(Constants.Windows.TitleWidth, Constants.Windows.TitleHeight);
            Add(titleWindow);

            var helpWindow = new HelpWindow(Constants.Windows.HelpWidth, Constants.Windows.HelpHeight);
            Add(helpWindow);

            var locationWindow = new LocationWindow(Constants.Windows.LocationWidth, Constants.Windows.LocationHeight);
            Add(locationWindow);

            var characterWindow = new CharacterWindow(Constants.Windows.CharacterWidth, Constants.Windows.CharacterHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(characterWindow);

            var keybindingsWindow = new KeybindingsWindow(Constants.Windows.KeybindingsWidth, Constants.Windows.KeybindingsHeight);
            Add(keybindingsWindow);

            var inventoryWindow = new InventoryWindow(Constants.Windows.InventoryWidth, Constants.Windows.InventoryHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(inventoryWindow);

            var viewItemWindow = new ViewItemWindow(Constants.Windows.ViewItemWidth, Constants.Windows.ViewItemHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(viewItemWindow);
        }

        // Add a new window to the manager
        public static void Add<T>(T userInterface) where T : IUserInterface
        {
            Interfaces.Add(userInterface);
        }

        // Fetch an existing window from the manager
        public static T Get<T>() where T : IUserInterface
        {
            return Interfaces.OfType<T>().SingleOrDefault();
        }
    }
}

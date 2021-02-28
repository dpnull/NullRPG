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

        public static void Initialize()
        {
            var gameWindow = new GameWindow(Constants.GameWidth, Constants.GameHeight)
            {
                IsFocused = true,
                IsVisible = true
            };

            Add(gameWindow);

            var keybindingsWindow = new KeybindingsWindow(Constants.Windows.KeybindingsWidth, Constants.Windows.KeybindingsHeight);
            Add(keybindingsWindow);

            var statsWindow = new StatsWindow(Constants.Windows.StatsWidth, Constants.Windows.StatsHeight);
            Add(statsWindow);

            var characterWindow = new CharacterWindow(Constants.Windows.CharacterWidth, Constants.Windows.CharacterHeight)
            {
                IsVisible = false,
                IsFocused = false
            };
            Add(characterWindow);

            IsInitialized = true;
        }

        public static void AutoVisiblity()
        {
            CheckVisibility(Get<StatsWindow>(), Get<CharacterWindow>().IsVisible);
        }

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

        public static void Add<T>(T userInterface) where T : IUserInterface
        {
            Interfaces.Add(userInterface);
        }

        public static T Get<T>() where T : IUserInterface
        {
            return Interfaces.OfType<T>().SingleOrDefault();
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return Interfaces.OfType<T>().ToArray();
        }

        public static void Remove<T>(T userInterface) where T : IUserInterface
        {
            Interfaces.Remove(userInterface);
        }

    }


}

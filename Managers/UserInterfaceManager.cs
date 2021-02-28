using NullRPG.Interfaces;
using System.Collections.Generic;
using NullRPG.Windows;
using System.Linq;

namespace NullRPG.Managers
{
    public static class UserInterfaceManager
    {
        private static readonly List<IUserInterface> Interfaces = new List<IUserInterface>();

        public static bool IsPaused { get; set; }
        public static bool IsInitialized { get; set; }

        public static void Initialize()
        {
            var gameWindow = new GameWindow(Constants.GameWidth, Constants.GameHeight);
            Add(gameWindow);

            var titleWindow = new TitleWindow(Constants.Windows.TitleWidth, Constants.Windows.TitleHeight);
            Add(titleWindow);

            var helpWindow = new HelpWindow(Constants.Windows.HelpWidth, Constants.Windows.HelpHeight)
            {
                IsVisible = false,
                IsFocused = false,
                IsPaused = true
            };
            Add(helpWindow);

            IsInitialized = true;
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

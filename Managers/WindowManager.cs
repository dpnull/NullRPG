using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Managers
{
    public class WindowManager
    {
        public WindowManager()
        {

        }

        public void OpenTravelWindow()
        {
            UserInterfaceManager.Get<TravelWindow>().ShowAndFocus();
        }

        public void OpenCharacterWindow()
        {
            UserInterfaceManager.Get<CharacterWindow>().ShowAndFocus();
        }

        // Currently always sends back to game window
        public void CloseCurrentWindow(SadConsole.Console window)
        {
            window.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }

        // Perhaps move this somewhere else
        public void Travel(Location loc)
        {
            Game.GameSession.Player.TravelToLocation(loc);
        }
    }
}

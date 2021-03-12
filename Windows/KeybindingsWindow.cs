using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using System.Linq;
using SadConsole.Input;
using NullRPG.Input;
using NullRPG.Windows.Navigation;

namespace NullRPG.Windows
{
    public class KeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;
        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.KeybindingsX, Constants.Windows.KeybindingsY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            var characterWindow = UserInterfaceManager.Get<CharacterWindow>();
            var generalKeybindings = UserInterfaceManager.Get<GeneralKeybindingsWindow>();
            var locationKeybindings = UserInterfaceManager.Get<LocationKeybindingsWindow>();
            var characterKeybindings = UserInterfaceManager.Get<CharacterKeybindingsWindow>();

            if (characterWindow.IsVisible)
            {
                characterKeybindings.Draw();
            }
            else
            {
                generalKeybindings.Draw();
                locationKeybindings.Draw();
            }

            characterKeybindings.IsVisible = characterWindow.IsVisible ? true : false;
            locationKeybindings.IsVisible = characterWindow.IsVisible ? false : true;
            generalKeybindings.IsVisible = characterWindow.IsVisible ? false : true;

            
            base.Draw(timeElapsed);
        }

    }
}

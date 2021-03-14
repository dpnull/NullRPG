using Microsoft.Xna.Framework;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Navigation;
using SadConsole;
using System;
using Console = SadConsole.Console;

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
            var actionKeybindings = UserInterfaceManager.Get<ActionKeybindingsWindow>();

            generalKeybindings.Draw();

            if (characterWindow.IsVisible)
            {
                characterKeybindings.Draw();
            }
            else
            {
                locationKeybindings.Draw();
                actionKeybindings.Draw();
            }

            characterKeybindings.IsVisible = characterWindow.IsVisible ? true : false;
            locationKeybindings.IsVisible = characterWindow.IsVisible ? false : true;

            base.Draw(timeElapsed);
        }
    }
}
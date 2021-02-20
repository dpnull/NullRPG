using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole.Controls;
using NullRPG.Extensions;
using SadConsole.Input;

namespace NullRPG.Windows
{
    public class TitleWindow : Console, IUserInterface
    {
        public HelpWindow HelpWindow { get; set; }

        public Console Console
        {
            get { return this; }
        }

        private readonly string Title = $"{Constants.GameTitle} {Constants.Build}";

        public TitleWindow(int width, int height) : base(width, height)
        {
            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            // Add it to the children of the main console
            Global.CurrentScreen.Children.Add(this);

            DrawGameTitle();
            DrawButtons();
        }

        // remember to eventually use public override void On[...]

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                Initialize();
                Start();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                OpenHelpWindow();
                return true;
            }

            if (info.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.D3))
            {
                Environment.Exit(0);
                return true;
            }

            return false;
        }

        private void DrawGameTitle()
        {
            Print(0, 0, "EARLY TESTING");
            string[] titleFragments = @"
                       .-.                 _    
                      /   \              _/ \             
         _        .--'\/\_ \            /    \       ___
        / \_    _/ ^      \/\ __        /\/\  /\  __/   \  
       /    \  /    .'   _/  /  \     /    \/  \/ .`'\_/\    
      /\/\  /\/ :' __  ^/  ^/    `--./.'  ^  `-.\ _    _:\ _
     /    \/  \  _/  \-' __/.' ^ _   \_   .'\   _/ \ .  __/ \
   /\  .-   `. \/     \ / -.   _/ \ -. `_/   \ /    `._/  ^  \
  /  `-.__ ^   / .-'.--'    . /    `--./ .-'  `-.  `-. `.  -  `.
 /        `.  / /      `-.   /  .-'   / .   .'   \    \  \  .-  \
"
.Replace("\r", string.Empty).Split('\n');

            int startPosX = (Constants.GameWidth / 2) - (titleFragments.OrderByDescending(a => a.Length).First().Length / 2);
            int startPosY = 0;

            // Print title fragments
            for (int y = 0; y < titleFragments.Length; y++)
            {
                for (int x = 0; x < titleFragments[y].Length; x++)
                {
                    Print(startPosX + x, startPosY + y, new ColoredGlyph(titleFragments[y][x], Color.White, Color.Transparent));
                }
            }

            this.PrintInsideSeparators(this.GetWindowYCenter(), Title, true, Color.LightGreen);
        }
        
        private void DrawButtons()
        {
            this.PrintButton(this.GetWindowXCenter(), this.GetWindowYCenter() + 2, "Play", '1', Color.DarkGreen, true);
            this.PrintButton(this.GetWindowXCenter(), this.GetWindowYCenter() + 3, "Help", '2', Color.DarkGreen, true);
            this.PrintButton(this.GetWindowXCenter(), this.GetWindowYCenter() + 4, "Quit", '3', Color.DarkGreen, true);
        }

        public static TitleWindow Show()
        {
            var titleWindow = UserInterfaceManager.Get<TitleWindow>();

            titleWindow.IsVisible = true;

            Global.CurrentScreen = titleWindow;

            return titleWindow;
        }

        /*
        private static void Hide(Console transitionConsole)
        {
            var titleWindow = UserInterfaceManager.Get<TitleWindow>();

            titleWindow.IsVisible = false;

            transitionConsole.IsVisible = true;

            Global.CurrentScreen = transitionConsole;
        }

        public static void Transition(Console transitionConsole)
        {
            Hide(transitionConsole);

        }
        */

        private void OpenHelpWindow()
        {
            this.Transition(UserInterfaceManager.Get<HelpWindow>());
        }

        private void Start()
        {
            this.Transition(UserInterfaceManager.Get<GameWindow>());
        }

        private void Initialize()
        {
            var keybindingsWindow = new KeybindingsWindow(Constants.Windows.KeybindingsWidth, Constants.Windows.KeybindingsHeight);
            UserInterfaceManager.Add(keybindingsWindow);
        }
    }
}

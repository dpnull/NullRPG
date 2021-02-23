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

        public TitleWindow(int width, int height) : base(width, height)
        {
            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            // Add it to the children of the main console
            Global.CurrentScreen.Children.Add(this);

            DrawGameTitle();
            DrawButtons();
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
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
            Print(Width - (Constants.Build.Length), Height - 1, Constants.Build);

            string[] titleFragments = @"
                       .-.                 _    
                      /   \              _/ \  
         _        .--'\/\_ \            /    \      ___
        / \_    _/ ^      \/\ __       /\/\  /\  __/   \  
       /    \  /    .'   _/  /  \     /    \/  \/ .`'\_/\    
      /\/\  /\/ :' __  ^/  ^/    `--./.'  ^  `-.\ _    _:\ _
     /    \/  \  _/  \-' __/.' ^ _   \_   .'\   _/ \ .  __/ \
   /\  .-   `. \/     \ / -.   _/ \ -. `_/   \ /    `._/  ^  \
  /  `-.__ ^   / .-'.--'    . /    `--./ .-'  `-.  `-. `.  -  `.
 /        `.  / /      `-.   /  .-'   / .   .'   \    \  \  .-  \
"
.Replace("\r", string.Empty).Split('\n');

            string[] gameNameFragments = @"
  _   _ _    _ _      _      _____  _____   _____ 
 | \ | | |  | | |    | |    |  __ \|  __ \ / ____|
 |  \| | |  | | |    | |    | |__) | |__) | |  __ 
 | . ` | |  | | |    | |    |  _  /|  ___/| | |_ |
 | |\  | |__| | |____| |____| | \ \| |    | |__| |
 |_| \_|\____/|______|______|_|  \_\_|     \_____|

".Replace("\r", string.Empty).Split('\n');

            int gStartPosX = (Constants.GameWidth / 2) - (titleFragments.OrderByDescending(a => a.Length).First().Length / 2);
            int gStartPosY = 0;

            // Print title fragments
            for (int y = 0; y < titleFragments.Length; y++)
            {
                for (int x = 0; x < titleFragments[y].Length; x++)
                {
                    Print(gStartPosX + x, gStartPosY + y + 1, new ColoredGlyph(titleFragments[y][x], Color.White, Color.Transparent));
                }
            }



            int tStartPosX = (Constants.GameWidth / 2) - (gameNameFragments.OrderByDescending(a => a.Length).First().Length / 2);
            int tStartPosY = this.GetWindowYCenter() - 1;

            this.PrintSeparator(tStartPosY + 8);
            this.PrintSeparator(tStartPosY);

            // Print game name fragments
            for (int y = 0; y < gameNameFragments.Length; y++)
            {
                for (int x = 0; x < gameNameFragments[y].Length; x++)
                {
                    Print(tStartPosX + x, tStartPosY + y, new ColoredGlyph(gameNameFragments[y][x], Color.Red, Color.Transparent));
                }
            }

        }
        
        private void DrawButtons()
        {
            this.PrintButton(this.GetWindowXCenter(), Height - 5, "Play", '1', Color.DarkGreen, true);
            this.PrintButton(this.GetWindowXCenter(), Height - 4, "Help", '2', Color.DarkGreen, true);
            this.PrintButton(this.GetWindowXCenter(), Height - 3, "Quit", '3', Color.DarkGreen, true);
            this.PrintSeparator(Height - 2);
        }

        public static TitleWindow Show()
        {
            var titleWindow = UserInterfaceManager.Get<TitleWindow>();

            titleWindow.IsVisible = true;

            Global.CurrentScreen = titleWindow;

            return titleWindow;
        }

        private void OpenHelpWindow()
        {
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<HelpWindow>());
        }

        private void Start()
        {
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }

    }
}

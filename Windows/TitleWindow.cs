using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Linq;
using NullRPG.Extensions;
using SadConsole.Input;
using NullRPG.Input;

namespace NullRPG.Windows
{
    public class TitleWindow : Console, IUserInterface
    {
        private ButtonString _playBtn;
        private ButtonString _helpBtn;
        private ButtonString _quitBtn;

        public Console Console
        {
            get { return this; }
        }

        public HelpWindow HelpWindow { get; private set; }

        public TitleWindow(int width, int height) : base(width, height)
        {
            SadConsole.Game.Instance.Window.Title = Constants.GameTitle;

            DrawGameTitle();
            // Also initializes the buttons
            DrawButtons();

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawGameTitle();
            DrawButtons();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(_playBtn.Key))
            {
                Start();
                return true;
            }

            if (info.IsKeyPressed(_helpBtn.Key))
            {
                OpenHelpWindow();
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

            this.DrawSeparator(tStartPosY + 8, "+", DefaultForeground);
            this.DrawSeparator(tStartPosY, "+", DefaultForeground);

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
            _playBtn = new ButtonString(new ColoredString("Play"), Microsoft.Xna.Framework.Input.Keys.D1, Color.Green, Color.White, 0, 0, true);
            _playBtn.Draw(this.GetWindowXCenter() - (_playBtn.GetLength() / 2), this.GetWindowYCenter() + 8, this);

            _helpBtn = new ButtonString(new ColoredString("Help"), Microsoft.Xna.Framework.Input.Keys.D2, Color.Green, DefaultForeground, 0, 0, true);
            _helpBtn.DrawNumericOnly(true);
            _helpBtn.Draw(this.GetWindowXCenter() - (_helpBtn.GetLength() / 2), this.GetWindowYCenter() + 9, this);

            _quitBtn = new ButtonString(new ColoredString("Quit"), Microsoft.Xna.Framework.Input.Keys.D3, Color.Green, DefaultForeground, 0, 0, true);
            _quitBtn.DrawNumericOnly(true);
            _quitBtn.Draw(this.GetWindowXCenter() - (_quitBtn.GetLength() / 2), this.GetWindowYCenter() + 10, this);
        }

        public static TitleWindow Show()
        {
            var titleWindow = UserInterfaceManager.Get<TitleWindow>();
            if(titleWindow == null)
            {
                titleWindow = new TitleWindow(Constants.Windows.TitleWidth, Constants.Windows.TitleHeight);
                UserInterfaceManager.Add(titleWindow);
            } else
            {
                titleWindow.IsVisible = true;
                titleWindow.IsFocused = true;
            }

            titleWindow.IsVisible = true;
            titleWindow.IsFocused = true;

            Global.CurrentScreen = titleWindow;

            return titleWindow;
        }

        private void OpenHelpWindow()
        {
            var helpWindow = UserInterfaceManager.Get<HelpWindow>();
            if(helpWindow == null)
            {
                helpWindow = new HelpWindow(Constants.Windows.HelpWidth, Constants.Windows.HelpHeight);
                UserInterfaceManager.Add(helpWindow);
                this.FullTransition(helpWindow);
            } else
            {
                this.FullTransition(helpWindow);
            }
        }

        private void Start()
        {
            UserInterfaceManager.Initialize();

            this.FullTransition(UserInterfaceManager.Get<GameWindow>());
        }
    }
}

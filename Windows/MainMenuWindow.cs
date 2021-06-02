using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Actors;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Editor;
using SadConsole;
using SadConsole.Input;
using System;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    internal class MainMenuWindow : Console, IUserInterface
    {
        private Button _playBtn;
        private Button _quitBtn;
        private Button _editorBtn;

        public Console Console
        {
            get { return this; }
        }

        public MainMenuWindow(int width, int height) : base(width, height)
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

            if (info.IsKeyPressed(_editorBtn.Key))
            {
                Editor();
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D9))
            {

            }

            return false;
        }


        private void DrawGameTitle()
        {
            Print(0, 0, "EARLY TESTING");
            Print(Width - (Constants.GameBuildVersion.Length), Height - 1, Constants.GameBuildVersion);

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

            this.DrawSeparator(tStartPosY + 8, "+", Constants.Theme.DefaultForeground);
            this.DrawSeparator(tStartPosY, "+", Constants.Theme.DefaultForeground);

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
            _playBtn = new Button("Play", 0, 4, Microsoft.Xna.Framework.Input.Keys.D1, Color.Green, DefaultForeground, DefaultBackground, false, true);
            _playBtn.Draw(this, this.GetWindowXCenter() - (_playBtn.GetLength() / 2), this.GetWindowYCenter() + 8);

            _editorBtn = new Button("Editor", 0, 4, Microsoft.Xna.Framework.Input.Keys.D2, Color.Green, DefaultForeground, DefaultBackground, false, true);
            _editorBtn.Draw(this, this.GetWindowXCenter() - (_playBtn.GetLength() / 2), this.GetWindowYCenter() + 9);

            _quitBtn = new Button("Quit", 0, 4, Microsoft.Xna.Framework.Input.Keys.D3, Color.Green, DefaultForeground, DefaultBackground, false, true);
            _quitBtn.Draw(this, this.GetWindowXCenter() - (_quitBtn.GetLength() / 2), this.GetWindowYCenter() + 10);
        }

        public static MainMenuWindow Show()
        {
            var mainMenuWindow = UserInterfaceManager.Get<MainMenuWindow>();
            if (mainMenuWindow == null)
            {
                mainMenuWindow = new MainMenuWindow(Constants.Windows.MainMenuWidth, Constants.Windows.MainMenuHeight);
                UserInterfaceManager.Add(mainMenuWindow);
            }
            else
            {
                mainMenuWindow.IsVisible = true;
                mainMenuWindow.IsFocused = true;
            }

            mainMenuWindow.IsVisible = true;
            mainMenuWindow.IsFocused = true;

            Global.CurrentScreen = mainMenuWindow;

            return mainMenuWindow;
        }

        /*
        private void OpenHelpWindow()
        {
            var helpWindow = UserInterfaceManager.Get<HelpWindow>();
            if (helpWindow == null)
            {
                helpWindow = new HelpWindow(Constants.Windows.HelpWidth, Constants.Windows.HelpHeight);
                UserInterfaceManager.Add(helpWindow);
                this.FullTransition(helpWindow);
            }
            else
            {
                this.FullTransition(helpWindow);
            }
        }*/

        private void Start()
        {
            UserInterfaceManager.Initialize();

            var spawnPosition = GridManager.Grid.GetCell(a => a.CellProperties.Walkable);
            Game.GameSession.PlayerActor = MapEntityManager.Create<PlayerActor>(spawnPosition.Position, GridManager.ActiveBlueprint.ObjectId);
            Game.GameSession.PlayerActor.Initialize();
            Game.GameSession.Player.Initialize();

            this.FullTransition(UserInterfaceManager.Get<GameWindow>());
        }

        private void Editor()
        {
            var editorWindow = new EditorWindow(Constants.GameWidth, Constants.GameHeight);
            UserInterfaceManager.Add(editorWindow);
            this.FullTransition(UserInterfaceManager.Get<EditorWindow>());
        }
    }
}
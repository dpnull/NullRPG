using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.GameObjects;
using SadConsole.Controls;
using SadConsole.Themes;

namespace NullRPG.Windows
{
    public class TravelWindow : ControlsConsole, IUserInterface
    {
        private List<SelectionButton> SelectionButtons = new List<SelectionButton>();

        public Console Console
        {
            get { return this; }
        }

        public TravelWindow(int width, int height) : base(width, height)
        {

            AssignKeybindings(Game.GameSession.World);

            var colors = Colors.CreateDefault();
            colors.ControlBack = Color.Black;
            colors.Text = Color.White;
            colors.TitleText = Color.White;
            colors.ControlHostBack = Color.White;

            Library.Default.SetControlTheme(typeof(Button), new ButtonLinesTheme());
            colors.RebuildAppearances();

            ThemeColors = colors;

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            DrawLocations();
            base.Update(timeElapsed);
        }

        private void DrawLocations()
        {
            int x = 5;
            int y = 3;
            foreach(SelectionButton button in SelectionButtons)
            {
                button.Position = new Point(x, y);
                y += 3;
            }
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                CloseTravelWindow();
                return true;
            }

            return false;
        }

        private void AssignKeybindings(World world)
        {
            foreach (Location location in world.GetLocations())
            {
                AddSelectionButton(location.Name);
            }
        }

        private void AddSelectionButton(string text)
        {
            Button3dTheme btnTheme = new Button3dTheme();

            SelectionButton selectionButton = new SelectionButton(15, 1)
            {
                Text = text
            };

            selectionButton.UseMouse = false;
            selectionButton.UseKeyboard = true;

            selectionButton.Theme = btnTheme;

            SelectionButtons.Add(selectionButton);
            Add(selectionButton);
           
        }

        private void CloseTravelWindow()
        {
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }
    }
}

using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Navigation
{
    public class GeneralKeybindingsWindow : Console, IUserInterface, IKeybindingsWindow
    {
        public Console Console => this;

        private Keybindings Keybindings = new Keybindings();

        public List<ButtonString> Buttons { get; set; }

        public GeneralKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.GeneralKeybindingsX, Constants.Windows.GeneralKeybindingsY);

            Initialize();
            Keybindings.UpdateKeybindings();
            RefractoredDrawKeybindings();

            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
        }

        public void Draw()
        {
            Clear();

            Keybindings.UpdateKeybindings();

            RefractoredDrawKeybindings();
        }

        private void RefractoredDrawKeybindings()
        {
            Buttons = new List<ButtonString>();
            int _x = 2;
            int _y = 1;

            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);

            for (int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                var btn = new ButtonString(new ColoredString(Keybindings.GetKeybindings()[i].TypeName.ToString()), Keybindings.GetKeybindings()[i].Key, Color.Green, DefaultForeground, _x, _y);
                Buttons.Add(btn);

                _y++;
            }

            foreach (var btn in Buttons)
            {
                btn.Draw(this);
            }
        }

        public void Initialize()
        {
            Keybindings.CreateKeybindings();
        }

        public void OnDraw()
        {
        }
    }
}
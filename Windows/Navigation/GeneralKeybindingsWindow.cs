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

namespace NullRPG.Windows.Navigation
{
    public class GeneralKeybindingsWindow : Console, IUserInterface, IKeybindingsWindow
    {
        public Console Console => this;

        Keybindings Keybindings = new Keybindings();

        public List<ButtonString> Buttons { get; set; }

        public GeneralKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.GeneralKeybindingsX, Constants.Windows.GeneralKeybindingsY);

            Initialize();
            Keybindings.UpdateKeybindings();
            RefractoredDrawKeybindings();

            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            Keybindings.UpdateKeybindings();

            RefractoredDrawKeybindings();

            base.Draw(timeElapsed);
        }

        private void RefractoredDrawKeybindings()
        {
            Buttons = new List<ButtonString>();
            int _x = 1;
            int _y = 1;

            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);

            for(int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                var btn = new ButtonString(new ColoredString(Keybindings.GetKeybindings()[i].TypeName.ToString()), Keybindings.GetKeybindings()[i].Key, Color.Green, DefaultForeground, _x, _y);
                Buttons.Add(btn);

                _y++;
            }

            foreach(var btn in Buttons)
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

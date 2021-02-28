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

namespace NullRPG.Windows
{
    public class KeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;

        Keybindings Keybindings = new Keybindings();

        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, Constants.GameHeight - Constants.Windows.KeybindingsHeight);

            Initialize();
            RefractoredDrawKeybindings();

            Global.CurrentScreen.Children.Add(this);
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

            int x = 3;

            List<Button> buttons = new List<Button>();

            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);

            for(int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                var btn = new Button(Keybindings.GetKeybindings()[i], Color.Green, DefaultForeground, x, 1);
                buttons.Add(btn);
                x += 3;
                
            }

            foreach(var btn in buttons)
            {
                btn.Draw(this);
            }
        }

        public void Initialize()
        {
            Keybindings.CreateKeybindings();
        }
    }
}

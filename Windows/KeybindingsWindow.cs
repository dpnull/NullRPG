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
            DrawKeybindings();

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawKeybindings();

            Keybindings.UpdateKeybindings();


            base.Draw(timeElapsed);
        }

        private void DrawKeybindings()
        {
            // NEEDS HEAVY REFRACTORING



            int x = 3; // spacing between each button

            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);

            for (int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                this.DrawButton(x, 1, Keybindings.GetKeybindings()[i].TypeName.ToString(),
                    Keybindings.GetKeybindings()[i].Key.ToString(), Color.Green, false);

                string offset = $"[{Keybindings.GetKeybindings()[i].Key}] {Keybindings.GetKeybindings()[i].TypeName}";
                x += offset.Length + 2;
            }
        }

        public void Initialize()
        {
            Keybindings.CreateKeybindings();
        }
    }
}

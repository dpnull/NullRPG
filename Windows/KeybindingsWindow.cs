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
using NullRPG.Factories;

namespace NullRPG.Windows
{
    public class KeybindingsWindow : Console, IUserInterface
    {
        Keybindings Keybindings = new Keybindings();
        public Console Console
        {
            get { return this; }
        }

        int test = 1;
        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            // Instantiate keybindings
            
            Position = new Point(0, Constants.GameHeight - height);

            // for testing purposes
            DefaultBackground = Color.DarkGray;

            Initialize();

            

            Global.CurrentScreen.Children.Add(this);
        }


        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            PrintKeybindings();

            Keybindings.UpdateKeybindings();
            
            base.Draw(timeElapsed);         
        }

        public void PrintKeybindings()
        {
            int x = 0;
            for (int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible)
                {
                    continue;
                }

                this.PrintButton(0, x, Keybindings.GetKeybindings()[i].TypeName.ToString(),
                    char.Parse(Keybindings.GetKeybindings()[i].Key.ToString()), Color.DarkGreen, true);
                x++;
            }

        }

        public void Initialize()
        {
            Keybindings.CreateKeybindings();
        }
    }
}
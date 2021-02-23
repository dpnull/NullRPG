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

        public KeybindingsWindow(int width, int height) : base(width, height)
        {
            // Instantiate keybindings
            
            Position = new Point(0, Constants.GameHeight - height);

            Initialize();
           
            Global.CurrentScreen.Children.Add(this);
        }


        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawKeybindings();

            Keybindings.UpdateKeybindings();
            
            base.Draw(timeElapsed);         
        }

        public void DrawKeybindings()
        {
            // Needs to be refractored heavily

            int x = 3; // spacing between each button
            
            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);

            
            for (int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                if (Keybindings.GetKeybindings()[i].TypeName == Keybindings.Type.View)
                {
                    string viewStr = $"[1 - 9] {Keybindings.GetKeybindings()[i].TypeName}";
                    Print(Width - viewStr.Length - 3, 1, viewStr, Color.AntiqueWhite);
                }
                if(Keybindings.GetKeybindings()[i].TypeName != Keybindings.Type.View)
                {
                    this.PrintButton(x, 1, Keybindings.GetKeybindings()[i].TypeName.ToString(),
                        char.Parse(Keybindings.GetKeybindings()[i].Key.ToString()), Color.Green, false);
                    // temporary soltuion
                    string offset = $"[{Keybindings.GetKeybindings()[i].Key}] {Keybindings.GetKeybindings()[i].TypeName}";
                    x += offset.Length + 2;
                }

            }
        }

        public void Initialize()
        {
            Keybindings.CreateKeybindings();
        }
    }
}
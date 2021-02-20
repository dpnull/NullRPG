﻿using System;
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

            PrintKeybindings();

            Keybindings.UpdateKeybindings();
            
            base.Draw(timeElapsed);         
        }

        public void PrintKeybindings()
        {
            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);
            int x = 3;
            for (int i = 0; i < Keybindings.GetKeybindings().Count; i++)
            {
                if (!Keybindings.GetKeybindings()[i].IsVisible)
                {
                    continue;
                }

                this.PrintButton(x, 1, Keybindings.GetKeybindings()[i].TypeName.ToString(),
                    char.Parse(Keybindings.GetKeybindings()[i].Key.ToString()), Color.Green, false);
                // temporary soltuion
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
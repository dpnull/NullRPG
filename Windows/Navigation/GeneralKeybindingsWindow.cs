﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Navigation
{
    public class GeneralKeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;

        public IKeybinding[] Keybindings { get; private set; }

        public List<Button> Buttons { get; set; }

        public GeneralKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.Keybindings.GeneralX, Constants.Windows.Keybindings.GeneralY);

            KeybindingManager.Initialize();

            Initialize();

            RefractoredDrawKeybindings();

            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
        }

        public void Draw()
        {
            Clear();

            Keybindings = KeybindingManager.GetCategoryKeybindings<IKeybinding>(Keybinding.Category.General);
            KeybindingManager.UpdateKeybindings();

            RefractoredDrawKeybindings();
        }

        private void RefractoredDrawKeybindings()
        {
            Buttons = new List<Button>();
            int _xSpacing = 2;
            int _x = 0;
            int _y = 1;

            this.DrawSeparator(0, "-", DefaultForeground);

            for (int i = 0; i < Keybindings.Length; i++)
            {
                if (!Keybindings[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                var btn = new Button(Keybindings[i].Name.ToString(), _x, _y, Keybindings[i].Key, Color.Green, DefaultForeground, DefaultBackground, false, true);

                Buttons.Add(btn);

                _x += btn.GetFormattedButton().Count + _xSpacing;
            }

            
            foreach (var btn in Buttons)
            {
                btn.Draw(this);
            }
            

        }

        public void Initialize()
        {
            Keybindings = KeybindingManager.GetCategoryKeybindings<IKeybinding>(Keybinding.Category.General);
        }

        public void OnDraw()
        {
        }
    }
}
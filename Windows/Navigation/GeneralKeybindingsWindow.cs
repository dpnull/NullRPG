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
    public class GeneralKeybindingsWindow : Console, IUserInterface, IKeybindingsWindow
    {
        public Console Console => this;

        public IKeybinding[] Keybindings { get; private set; }

        public List<ButtonString> Buttons { get; set; }

        public GeneralKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.GeneralKeybindingsX, Constants.Windows.GeneralKeybindingsY);

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
            Buttons = new List<ButtonString>();
            int _x = 2;
            int _y = 1;

            this.DrawBorders(Width, Height, "+", "|", "-", DefaultForeground);

            for (int i = 0; i < Keybindings.Length; i++)
            {
                if (!Keybindings[i].IsVisible) // don't iterate through hidden keybindings
                {
                    continue;
                }

                var btn = new ButtonString(new ColoredString(Keybindings[i].Name.ToString()), Keybindings[i].Key, Color.Green, DefaultForeground, _x, _y);
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
            Keybindings = KeybindingManager.GetCategoryKeybindings<IKeybinding>(Keybinding.Category.General);
        }

        public void OnDraw()
        {
        }
    }
}
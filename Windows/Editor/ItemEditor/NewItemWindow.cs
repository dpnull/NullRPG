using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Editor.ItemEditor
{
    public class NewItemWindow : Console, IUserInterface, IInputBox
    {
        private string _input;
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                if (_input != null)
                {
                    if (ItemName != _input)
                    {
                        ItemName = _input;
                    }
                }
                
            }
        }
        public Console Console => this;

        private ButtonString itemNameBtn;
        private ButtonString itemIsStackableBtn;
        private ButtonString itemComponentsBtn;

        public string ItemName { get; set; }
        public bool IsStackable { get; set; } = true;

        public NewItemWindow(int width, int height) : base(width, height)
        {

        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawKeybindings();

            if (ItemName != null)
            {
                Print(20, 4, $": {ItemName}");
                
            }

            DrawIsStackable();

            base.Draw(timeElapsed);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            itemNameBtn = new ButtonString(new ColoredString("Name"), Microsoft.Xna.Framework.Input.Keys.D1, Color.Green, DefaultForeground, 0, 4, true);
            itemIsStackableBtn = new ButtonString(new ColoredString("Is stackable?"), Microsoft.Xna.Framework.Input.Keys.D2, Color.Green, DefaultForeground, 0, 5, true);
            itemComponentsBtn = new ButtonString(new ColoredString("Item components"), Microsoft.Xna.Framework.Input.Keys.D3, Color.Green, DefaultForeground, 0, 6, true);


            base.Update(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D1))
            {
                GetInput();
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.D2))
            {
                SetStackable();
            }

            return false;
        }

        private void SetStackable()
        {
            IsStackable = IsStackable is false ? true : false;
        }

        private void DrawIsStackable()
        {
            ColoredString yesStr = new ColoredString("Yes");
            ColoredString noStr = new ColoredString("No");

            if (IsStackable)
            {
                yesStr.SetBackground(Color.Green);
                noStr.SetBackground(DefaultBackground);
            } else
            {
                yesStr.SetBackground(DefaultBackground);
                noStr.SetBackground(Color.Green);
            }

            Print(20, 5, yesStr);
            Print(24, 5, noStr);
        }

        private void DrawKeybindings()
        {

            itemNameBtn.Draw(this);
            itemIsStackableBtn.Draw(this);
            itemComponentsBtn.Draw(this);
        }

        private void GetInput()
        {
            if(UserInterfaceManager.Get<InputWindow>() is null)
            {
                var inputBox = new InputBox(this);
                inputBox.Init(this);
                //inputBox.Delete();
            }
        }
    }
}

using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Editor.ItemEditor;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Editor
{
    public class InputWindow : Console, IUserInterface, IInputBox
    {
        public string Input { get; set; }
        public Console Console { get; }
        private readonly List<char> Keys = new List<char>();
        public bool InputObtained { get; set; } = false;
        public IUserInterface TransitionConsole { get; set; }
        private readonly IInputBox Caller;

        public InputWindow(IInputBox caller) : base(Constants.Editor.EDITOR_INPUT_W, Constants.Editor.EDITOR_INPUT_H)
        {
            Caller = caller;
            Position = new Point((Constants.GameWidth / 2) - (Width / 2), (Constants.GameHeight / 2) - (Height / 2));
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            this.DrawRectangleTitled(0, 0, Width, Height - 1, "+", "-", "|", "-", new ColoredString("Input:"), true);

            DrawInput();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            foreach(var c in info.KeysPressed)
            {
                if(c.Character > 65 && c.Character < 122)
                {
                    Keys.Add(c.Character);
                    return true;
                }
                
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                Keys.Add(' ');
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Back))
            {
                if(Keys.Count > 0)
                    Keys.RemoveAt(Keys.Count - 1);
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                if (TransitionConsole != null)
                {
                    InputObtained = true;
                    Caller.Input = new string(Keys.ToArray());
                    this.FullTransition(TransitionConsole.Console);
                    this.Delete();
                    UserInterfaceManager.Remove(this);
                }
                return true;
            }

            return false;
        }

        private void DrawInput()
        {
            if (Keys != null)
            {
                int _x = 2;

                foreach (var key in Keys)
                {                  
                    Print(_x, Height - 2, $"{key} _"); _x++;
                }
            }

        }

        public void Delete()
        {     
            UserInterfaceManager.Remove(this);
        }


    }
}

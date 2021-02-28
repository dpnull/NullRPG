using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NullRPG
{
    public class Button
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public Keys Key { get; set; }
        public Color KeyColor { get; set; }
        public Color TextColor { get; set; }
        public bool NumericOnly { get; set; }

        public Button(Keybindings keybinding, Color keyColor, Color textColor, int x = 0, int y = 0)
        {
            Name = keybinding.TypeName.ToString();
            Key = Key;
            KeyColor = keyColor;
            TextColor = textColor;

            X = x;
            Y = y;
            NumericOnly = false;
        }

        public Button(string name, Keys key, Color keyColor, Color textColor, int x = 0, int y = 0)
        {
            Name = name;
            Key = key;
            KeyColor = keyColor;
            TextColor = textColor;

            X = x;
            Y = y;
            NumericOnly = false;
        }


        public void DrawNumericOnly(bool b)
        {
            if (b)
            {
                NumericOnly = true;
            }
            else
            {
                NumericOnly = false;
            }
        }

        private string KeyString()
        {
            if (NumericOnly)
            {
                return Keybindings.GetNumericKeyName(Key);
            }
            else
            {
                return Key.ToString();
            }
        }

        public void Draw(SadConsole.Console console)
        {
            var bracketA = new SadConsole.ColoredString("[");
            bracketA.SetForeground(TextColor);
            var bracketB = new SadConsole.ColoredString("] ");
            bracketB.SetForeground(TextColor);

            var prefix = new SadConsole.ColoredString(KeyString());
            prefix.SetForeground(KeyColor);

            var suffix = new SadConsole.ColoredString($"{Name}");
            suffix.SetForeground(TextColor);

            var button = new SadConsole.ColoredString($"");
            button.SetForeground(TextColor);
            button.SetBackground(TextColor);

            button += bracketA + prefix + bracketB + suffix;
            console.Print(X - (button.Count / 2), Y, button);
        }

        public void Draw(SadConsole.Console console, int x, int y)
        {
            int _x = x;
            int _y = y;
            var bracketA = new SadConsole.ColoredString("[");
            bracketA.SetForeground(TextColor);
            var bracketB = new SadConsole.ColoredString("] ");
            bracketB.SetForeground(TextColor);

            var prefix = new SadConsole.ColoredString(KeyString());
            prefix.SetForeground(KeyColor);

            var suffix = new SadConsole.ColoredString($"{Name}");
            suffix.SetForeground(TextColor);

            var button = new SadConsole.ColoredString($"");
            button.SetForeground(TextColor);
            button.SetBackground(TextColor);

            button += bracketA + prefix + bracketB + suffix;
            console.Print(_x - (button.Count / 2), _y, button);
        }

    }
}

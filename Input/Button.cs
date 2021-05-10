using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Linq;

namespace NullRPG.Input
{
    public class Button : BaseButton
    {
        public Button(string name, int x, int y, Keys key, Color keyColor, Color nameColor, Color backgroundColor, bool isNumeric, bool isEnabled)
            : base(name, x, y, key, keyColor, nameColor, backgroundColor, isNumeric, isEnabled)
        {

        }

        public int GetLength()
        {
            return GetFormattedButton().Count;
        }

        // TEMPORARY **************
        public static string FormatKeyEnum(Keys key)
        {
            bool containsDigit = false;
            string str = key.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    containsDigit = true;
                    break;
                }
            }

            if (containsDigit)
            {
                string digitStr = "";
                foreach(var c in str)
                {
                    if (Char.IsDigit(c))
                        digitStr += c;
                }
                return digitStr;
            }
            else
            {
                return str;
            }
            
        }

        public override ColoredString GetFormattedKey(string prefix, string suffix)
        {
            var formatted = new SadConsole.ColoredString(FormatKeyEnum(Key), KeyColor, BackgroundColor);
            var p = new ColoredString(prefix, NameColor, BackgroundColor);
            var s = new ColoredString(suffix, NameColor, BackgroundColor);


            return p += formatted += s;
        }

        public override ColoredString GetFormattedButton()
        {
            var first = GetFormattedKey("[", "]");
            var second = new ColoredString(" ");
            second.SetForeground(Color.Transparent);
            second.SetBackground(Color.Black);
            var third = Name;
            third.SetBackground(Color.Black);
            third.SetForeground(Color.White);
            return !IsNumeric ? first + second + third : first;
        }

        public override void Draw(SadConsole.Console console)
        {
            var btnName = GetFormattedButton();

            console.Print(X, Y, btnName);
        }

        public override void Draw(SadConsole.Console console, int x, int y)
        {
            var btnName = GetFormattedButton();

            console.Print(x, y, btnName);
        }
    }
}

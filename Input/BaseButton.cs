using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;

namespace NullRPG.Input
{
    public abstract class BaseButton : IButton
    {
        public ColoredString Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Keys Key { get; set; }
        public Color KeyColor { get; set; }
        public Color NameColor { get; set; }
        public Color BackgroundColor { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsNumeric { get; set; }

        public BaseButton(string name, int x, int y, Keys key, Color keyColor, Color nameColor, Color backgroundColor, bool isNumeric, bool isEnabled)
        {
            Name = new SadConsole.ColoredString(name, backgroundColor, nameColor);
            X = x;
            Y = y;
            Key = key;
            KeyColor = keyColor;
            NameColor = nameColor;
            BackgroundColor = backgroundColor;
            IsNumeric = isNumeric;
            IsEnabled = isEnabled;
        }

        public abstract void Draw(SadConsole.Console console);
        public abstract ColoredString GetFormattedKey(string prefix, string suffix);
        public abstract ColoredString GetFormattedButton();
        public abstract void Draw(SadConsole.Console console, int x, int y);

        /// <summary>
        /// Set the button to only draw numeric variant.
        /// </summary>
        /// <param name="b">Condition for drawing.</param>
        public void DrawNumericOnly(bool b)
        {
            if (b)
            {
                IsNumeric = true;
            }
            else
            {
                IsNumeric = false;
            }
        }
        public virtual SadConsole.ColoredString GetButtonToString()
        {
            return null;
        }
    }
}
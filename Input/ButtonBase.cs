using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;

namespace NullRPG.Input
{
    public abstract class ButtonBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Keys Key { get; set; }
        public Color KeyColor { get; set; }
        public Color NameColor { get; set; }

        public bool IsNumeric { get; set; }

        public ButtonBase(int x, int y, Keys key, Color keyColor, Color nameColor, bool isNumeric)
        {
            X = x;
            Y = y;
            Key = key;
            KeyColor = keyColor;
            NameColor = nameColor;
            IsNumeric = isNumeric;
        }

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
        /// <summary>
        /// Convert XNA key to string.
        /// </summary>
        /// <returns>Returns XNA key string.</returns>
        public string KeyToString()
        {
            if (IsNumeric)
            {
                return KeybindingManager.GetKeyNameNumeric(Key);
            }
            else
            {
                return Key.ToString();
            }
        }
    }
}

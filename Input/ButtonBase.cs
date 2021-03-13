using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        public string KeyToString()
        {
            if (IsNumeric)
            {
                return Keybindings.GetNumericKeyName(Key);
            }
            else
            {
                return Key.ToString();
            }
        }
    }
}
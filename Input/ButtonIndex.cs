using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NullRPG.Input
{
    public class ButtonIndex : ButtonBase
    {
        public SadConsole.ColoredString KeyString { get; set; }

        public virtual int GetLength()
        {
            return KeyString.String.Length;
        }

        public ButtonIndex(Keys key, Color keyColor, Color nameColor, int x = 0, int y = 0, bool isNumeric = false) : base(x, y, key, keyColor, nameColor, isNumeric)
        {
            KeyString = FormatKeyDisplay();
        }

        private SadConsole.ColoredString FormatKeyDisplay()
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.BackgroundColor);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.BackgroundColor);
            var keyStr = new SadConsole.ColoredString(KeyToString(), KeyColor, Constants.Theme.BackgroundColor);

            return lBracketGlyph + keyStr + rBracketGlyph;
        }

        public virtual void Draw(SadConsole.Console console)
        {
            console.Print(X, Y, KeyString);
        }

        public virtual void Draw(int x, int y, SadConsole.Console console)
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.BackgroundColor);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.BackgroundColor);
            var keyString = new SadConsole.ColoredString(KeyToString(), KeyColor, Constants.Theme.BackgroundColor);

            var key = new SadConsole.ColoredString("");
            key += lBracketGlyph + keyString + rBracketGlyph;

            console.Print(x, y, key);
        }

    }
}

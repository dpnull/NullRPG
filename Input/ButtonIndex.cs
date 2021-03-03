using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NullRPG.Input
{
    public class ButtonIndex : ButtonBase
    {
        public ButtonIndex(Keys key, Color keyColor, Color nameColor, int x = 0, int y = 0) : base(x, y, key, keyColor, nameColor, true)
        {

        }

        public void Draw(SadConsole.Console console)
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.BackgroundColor);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.BackgroundColor);
            var keyString = new SadConsole.ColoredString(KeyString(), KeyColor, Constants.Theme.BackgroundColor);
            
            var key = new SadConsole.ColoredString("");
            key += lBracketGlyph + keyString + rBracketGlyph;

            console.Print(X, Y, key);
        }

        public void Draw(int x, int y, SadConsole.Console console)
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.BackgroundColor);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.BackgroundColor);
            var keyString = new SadConsole.ColoredString(KeyString(), KeyColor, Constants.Theme.BackgroundColor);

            var key = new SadConsole.ColoredString("");
            key += lBracketGlyph + keyString + rBracketGlyph;

            console.Print(x, y, key);
        }

    }
}

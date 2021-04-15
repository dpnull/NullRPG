using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole;

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
            KeyString = FormatKeyDisplay(keyColor);
        }

        public SadConsole.ColoredString FormatKeyDisplay(Color keyColor)
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.DefaultBackground);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.DefaultBackground);
            var keyStr = new SadConsole.ColoredString(KeyToString(), KeyColor, Constants.Theme.DefaultBackground);

            return lBracketGlyph + keyStr + rBracketGlyph;
        }

        public virtual void Draw(SadConsole.Console console)
        {
            console.Print(X, Y, KeyString);
        }

        public virtual void Draw(int x, int y, SadConsole.Console console)
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.DefaultBackground);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.DefaultBackground);
            var keyString = new SadConsole.ColoredString(KeyToString(), KeyColor, Constants.Theme.DefaultBackground);

            var key = new SadConsole.ColoredString("");
            key += lBracketGlyph + keyString + rBracketGlyph;

            console.Print(x, y, key);
        }

        public override ColoredString GetButtonToString()
        {
            var lBracketGlyph = new SadConsole.ColoredString("[", NameColor, Constants.Theme.DefaultBackground);
            var rBracketGlyph = new SadConsole.ColoredString("]", NameColor, Constants.Theme.DefaultBackground);
            var keyString = new SadConsole.ColoredString(KeyToString(), KeyColor, Constants.Theme.DefaultBackground);

            var key = new SadConsole.ColoredString("");
            key += lBracketGlyph + keyString + rBracketGlyph;

            return key;
        }
    }
}
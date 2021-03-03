using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace NullRPG.Input
{
    class ButtonString : ButtonIndex
    {
        public string Name { get; set; }

        public override int GetLength()
        {
            return base.GetLength() + Name.Length + 1; // 1 accounts for space
        }

        public ButtonString(string name, Keys key, Color keyColor, Color nameColor, int x = 0, int y = 0, bool isNumeric = false) : base(key, keyColor, nameColor, x, y, isNumeric)
        {
            Name = name;
        }

        public override void Draw(SadConsole.Console console)
        {
            var name = new SadConsole.ColoredString(Name, NameColor, Constants.Theme.BackgroundColor);

            var str = new SadConsole.ColoredString("");
            str += KeyString + " " + name;

            console.Print(X, Y, str);
        }

        public override void Draw(int x, int y, SadConsole.Console console)
        {
            var name = new SadConsole.ColoredString(Name, NameColor, Constants.Theme.BackgroundColor);

            var str = new SadConsole.ColoredString("");
            str += KeyString + " " + name;

            console.Print(x, y, str);
        }
    }
}

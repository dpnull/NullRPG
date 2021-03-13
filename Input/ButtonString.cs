using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole;

namespace NullRPG.Input
{
    public class ButtonString : ButtonIndex
    {
        public ColoredString Name { get; set; }

        public override int GetLength()
        {
            return base.GetLength() + Name.Count + 1; // 1 accounts for space
        }

        public ButtonString(ColoredString name, Keys key, Color keyColor, Color nameColor, int x = 0, int y = 0, bool isNumeric = false) : base(key, keyColor, nameColor, x, y, isNumeric)
        {
            Name = name;
        }

        public override void Draw(SadConsole.Console console)
        {
            var str = new SadConsole.ColoredString("");
            str += KeyString + " " + Name;
            str.SetBackground(console.DefaultBackground);

            console.Print(X, Y, str);
        }

        public override void Draw(int x, int y, SadConsole.Console console)
        {
            var str = new SadConsole.ColoredString("");
            str += KeyString + " " + Name;
            str.SetBackground(console.DefaultBackground);

            console.Print(x, y, str);
        }
    }
}
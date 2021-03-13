using Microsoft.Xna.Framework;
using System.Text;

namespace NullRPG.Extensions
{
    public static class ConsoleExtensions
    {
        public static void DrawSeparator(this SadConsole.Console console, int y, string corner, Color c)
        {
            StringBuilder separator = new StringBuilder();
            separator.Append(corner);
            for (int i = 1; i < console.Width - 1; i++)
            {
                separator.Append("-");
            }
            separator.Append(corner);

            console.Print(0, y, separator.ToString(), c);
        }

        public static void DrawHeaderInsideSeparators(this SadConsole.Console console, int y, string title, string corner, Color c)
        {
            DrawSeparator(console, y, corner, console.DefaultForeground);
            console.Print(console.GetWindowXCenter() - (title.Length / 2), y + 1, title, c);
            DrawSeparator(console, y + 2, corner, console.DefaultForeground);
        }

        public static void DrawHeader(this SadConsole.Console console, int y, string title, Color foregroundColor, Color backgroundColor)
        {
            var str = new SadConsole.ColoredString();
            str.String = title;
            str.SetForeground(foregroundColor);
            str.SetBackground(backgroundColor);
            console.Print(console.Width / 2 - (str.Count / 2), y, str);
        }

        // Can be improved
        public static void DrawButton(this SadConsole.Console console, int x, int y, string text, string key, Color keyColor, bool windowCentered)
        {
            var bracketA = new SadConsole.ColoredString("[");
            bracketA.SetForeground(console.DefaultForeground);
            var bracketB = new SadConsole.ColoredString("] ");
            bracketB.SetForeground(console.DefaultForeground);

            var prefix = new SadConsole.ColoredString($"{key}");
            prefix.SetForeground(keyColor);

            var suffix = new SadConsole.ColoredString($"{text}");
            suffix.SetForeground(console.DefaultForeground);

            var button = new SadConsole.ColoredString("");
            button.SetForeground(console.DefaultForeground);
            button.SetBackground(console.DefaultBackground);

            button += bracketA + prefix + bracketB + suffix;

            int _x = windowCentered ? (console.Width / 2 - (button.Count / 2)) : x;

            console.Print(_x, y, button);
        }

        public static void DrawRectangleTitled(this SadConsole.Console console, int x, int y, int width, int height, string cornerGlyph, string horizontalGlyph, string verticalGlyph, string separatorCornerGlyph, SadConsole.ColoredString title, bool centeredTitle)
        {
            int _x;
            int _y;

            // top
            for (_x = x + 1; _x < (x + width) - 1; _x++)
            {
                console.Print(_x, y, horizontalGlyph);
            }
            // draw top corners
            console.Print(x, y, cornerGlyph);
            console.Print(x + width - 1, y, cornerGlyph);

            // bottom
            for (_x = x + 1; _x < (x + width) - 1; _x++)
            {
                console.Print(_x, height + y, horizontalGlyph);
            }
            // draw bottom corners
            console.Print(x, height + y, cornerGlyph);
            console.Print(x + width - 1, height + y, cornerGlyph);

            // left
            for (_y = y + 1; _y < (y + height); _y++)
            {
                console.Print(x, _y, verticalGlyph);
            }

            // right
            for (_y = y + 1; _y < (y + height); _y++)
            {
                console.Print(x + width - 1, _y, verticalGlyph);
            }

            // draw title separator. simply draws on top of already drawn glyphs
            for (_x = x + 1; _x < (x + width) - 1; _x++)
            {
                console.Print(_x, y + 2, horizontalGlyph);
            }
            // draw separator corners
            console.Print(x, y + 2, separatorCornerGlyph);
            console.Print(x + width - 1, y + 2, separatorCornerGlyph);

            // draw the box title
            if (centeredTitle)
            {
                console.Print((width / 2) - (title.String.Length / 2), y + 1, title);
            }
            else
            {
                console.Print(2, y + 1, title);
            }
        }

        public static void DrawRectangle(this SadConsole.Console console, int x, int y, int width, int height, string cornerGlyph, string horizontalGlyph, string verticalGlyph)
        {
            int _x;
            int _y;

            // top
            for (_x = x + 1; _x < (x + width) - 1; _x++)
            {
                console.Print(_x, y, horizontalGlyph);
            }
            // draw top corners
            console.Print(x, y, cornerGlyph);
            console.Print(x + width - 1, y, cornerGlyph);

            // bottom
            for (_x = x + 1; _x < (x + width) - 1; _x++)
            {
                console.Print(_x, height + y, horizontalGlyph);
            }
            // draw bottom corners
            console.Print(x, height + y, cornerGlyph);
            console.Print(x + width - 1, height + y, cornerGlyph);

            // left
            for (_y = y + 1; _y < (y + height); _y++)
            {
                console.Print(x, _y, verticalGlyph);
            }

            // right
            for (_y = y + 1; _y < (y + height); _y++)
            {
                console.Print(x + width - 1, _y, verticalGlyph);
            }
        }

        public static void DrawBorders(this SadConsole.Console currentWindow, int width, int height, string cornerGlyph, string horizontalBorderGlyph, string verticalBorderGlyph, Color borderColor)
        {
            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (int colIndex = 0; colIndex < width; colIndex++)
                {
                    // Drawing Corners
                    if ((rowIndex == 0 && colIndex == 0)
                        || (rowIndex == height - 1 && colIndex == 0)
                        || (rowIndex == height - 1 && colIndex == width - 1)
                        || (rowIndex == 0 && colIndex == width - 1))
                    {
                        currentWindow.Print(colIndex, rowIndex, cornerGlyph, borderColor);
                    }

                    if (rowIndex > 0 && rowIndex < height - 1 && (colIndex == 0 || colIndex == width - 1))
                    {
                        currentWindow.Print(colIndex, rowIndex, horizontalBorderGlyph, borderColor);
                    }

                    if (colIndex > 0 && colIndex < width - 1 && (rowIndex == 0 || rowIndex == height - 1))
                    {
                        currentWindow.Print(colIndex, rowIndex, verticalBorderGlyph, borderColor);
                    }
                }
            }
        }

        public static SadConsole.ColoredString AttributeString(int value1, int value2, string attribute)
        {
            if (value1 == 0 && value2 == 0)
            {
                return null;
            }
            else
            {
                // currently draws everything as a positive value
                var pVal = Constants.Theme.PositiveAttributeColor;
                var cBg = Constants.Theme.BackgroundColor;
                var cFg = Constants.Theme.ForegroundColor;

                var val1 = new SadConsole.ColoredString(value1.ToString(), pVal, cBg);
                var val2 = new SadConsole.ColoredString(value2.ToString(), pVal, cBg);
                var att = new SadConsole.ColoredString(attribute, cFg, cBg);

                var separator = new SadConsole.ColoredString(" - ", cFg, cBg);

                var str = new SadConsole.ColoredString("+ ", cFg, cBg);

                return str + val1 + separator + val2 + " " + att;
            }
        }

        public static SadConsole.ColoredString AttributeString(int value, string attribute)
        {
            // currently draws everything as a positive value
            var pVal = Constants.Theme.PositiveAttributeColor;
            var nVal = Constants.Theme.NegativeAttributeColor;
            var cBg = Constants.Theme.BackgroundColor;
            var cFg = Constants.Theme.ForegroundColor;

            var val = new SadConsole.ColoredString(value.ToString());
            var att = new SadConsole.ColoredString(attribute, cFg, cBg);

            val.SetForeground(value > 0 ? pVal : nVal);

            var str = new SadConsole.ColoredString("+ ", cFg, cBg);

            return str + val + " " + att;
        }

        public static int GetWindowXCenter(this SadConsole.Console console)
        {
            return console.Width / 2;
        }

        public static int GetWindowYCenter(this SadConsole.Console console)
        {
            return console.Height / 2;
        }

        public static void FullTransition(this SadConsole.Console currentConsole, SadConsole.Console transition)
        {
            currentConsole.IsVisible = false;
            currentConsole.IsFocused = false;

            transition.IsVisible = true;
            transition.IsFocused = true;

            SadConsole.Global.CurrentScreen = transition;
        }

        public static void SwitchFocus(SadConsole.Console focusConsole)
        {
            focusConsole.IsFocused = true;
        }

        public static void SwitchFocusMakeVisible(this SadConsole.Console c, SadConsole.Console focusConsole)
        {
            focusConsole.IsVisible = true;
            focusConsole.IsFocused = true;
        }
    }
}
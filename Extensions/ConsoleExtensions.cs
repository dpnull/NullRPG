using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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

        public static void DrawRectangleTitled(this SadConsole.Console console, int x, int y, int width, int height, string cornerGlyph, string horizontalGlyph, string verticalGlyph, string separatorCornerGlyph, SadConsole.ColoredString title)
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

            // Draw the box title
            console.Print((width / 2) - (title.String.Length / 2), y + 1, title);
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
            currentConsole.IsPaused = true;

            transition.IsVisible = true;
            transition.IsFocused = true;
            transition.IsPaused = false;

            SadConsole.Global.CurrentScreen = transition;
        }
    }
}

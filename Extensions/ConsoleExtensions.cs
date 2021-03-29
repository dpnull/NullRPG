using Microsoft.Xna.Framework;
using System.Text;
using Console = SadConsole.Console;
using SadConsole;
using SadConsole.Input;

namespace NullRPG.Extensions
{
    public static class ConsoleExtensions
    {
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

        public static int GetWindowXCenter(this SadConsole.Console console)
        {
            return console.Width / 2;
        }

        public static int GetWindowYCenter(this SadConsole.Console console)
        {
            return console.Height / 2;
        }

        public static void SwitchFocusMakeVisible(this SadConsole.Console c, SadConsole.Console focusConsole)
        {
            focusConsole.IsVisible = true;
            focusConsole.IsFocused = true;
        }

        public static void FullTransition(this SadConsole.Console currentConsole, SadConsole.Console transition)
        {
            currentConsole.IsVisible = false;
            currentConsole.IsFocused = false;

            transition.IsVisible = true;
            transition.IsFocused = true;

            SadConsole.Global.CurrentScreen = transition;
        }
    }
}

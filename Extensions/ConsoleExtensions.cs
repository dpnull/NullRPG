using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace NullRPG.Extensions
{
    public static class ConsoleExtensions
    {
        public static void PrintSeparator(this SadConsole.Console currentWindow, int y)
        {
            StringBuilder separator = new StringBuilder();
            separator.Append("+");
            for (int i = 1; i < currentWindow.Width - 1; i++)
            {
                separator.Append("-");
            }
            separator.Append("+");

            currentWindow.Print(0, y, separator.ToString());
        }

        // Temporarily unused due to \n glyph glitch when using an already implemented Print function from SadConsole...
        public static void PrintWrappedText(this SadConsole.Console currentWindow, int xPos, int yPos, string text, Color color)
        {
            int x = 0; int y = 0;
            foreach (var c in text)
            {
                if (c == '\n') { x = 0; y++; continue; }
                else { x++; }
                currentWindow.Print(xPos + x, yPos + y, c.ToString(), color);
            }
        }

        public static void PrintWrappedText(this SadConsole.Console currentWindow, int xPos, int yPos, string text)
        {
            int x = 0; int y = 0;
            foreach (var c in text)
            {
                if (c == '\n') { x = 0; y++; continue; }
                else { x++; }
                currentWindow.Print(xPos + x, yPos + y, c.ToString());
            }
        }

        public static void PrintWrappedText(this SadConsole.Console currentWindow, int xPos, int yPos, SadConsole.ColoredString text)
        {
            int x = 0; int y = 0;
            foreach (var c in text.String)
            {
                if (c == '\n') { x = 0; y++; continue; }
                else { x++; }
                currentWindow.Print(xPos + x, yPos + y, c.ToString());
            }
        }

        public static void PrintWrappedText(this SadConsole.Console currentWindow, int xPos, int yPos, SadConsole.ColoredString text, Color color)
        {
            int x = 0; int y = 0;
            foreach (var c in text.String)
            {
                if (c == '\n') { x = 0; y++; continue; }
                else { x++; }
                currentWindow.Print(xPos + x, yPos + y, c.ToString(), color);
            }
        }
        //...
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

        public static void PrintInsideSeparators(this SadConsole.Console currentWindow, int y, string text, bool centered)
        {
            int _x = centered ? (currentWindow.Width / 2 - (text.Length / 2)) : 0;
            PrintSeparator(currentWindow, y - 1);
            currentWindow.Print(_x, y, text);
            PrintSeparator(currentWindow, y + 1);
        }

        public static void PrintInsideSeparators(this SadConsole.Console currentWindow, int y, string text, bool centered, Color color)
        {
            int x = centered ? (currentWindow.Width / 2 - (text.Length / 2)) : 0;
            PrintSeparator(currentWindow, y - 1);
            currentWindow.Print(x, y, text, color);
            PrintSeparator(currentWindow, y + 1);
        }

        public static void PrintButton(this SadConsole.Console currentWindow, int x, int y, string text, string key, Color keyColor, bool windowCentered)
        {
            var bracketA = new SadConsole.ColoredString("[");
            bracketA.SetForeground(currentWindow.DefaultForeground);
            var bracketB = new SadConsole.ColoredString("] ");
            bracketB.SetForeground(currentWindow.DefaultForeground);

            var prefix = new SadConsole.ColoredString($"{key}");
            prefix.SetForeground(keyColor);

            var suffix = new SadConsole.ColoredString($"{text}");
            suffix.SetForeground(currentWindow.DefaultForeground);

            var button = new SadConsole.ColoredString("");
            button.SetForeground(currentWindow.DefaultForeground);
            button.SetBackground(currentWindow.DefaultBackground);

            button += bracketA + prefix + bracketB + suffix;

            int _x = windowCentered ? (currentWindow.Width / 2 - (button.Count / 2)) : x;

            currentWindow.Print(_x, y, button);
        }

        //TODO
        public static void PrintButtonsHorizontally(this SadConsole.Console currentWindow, int x, int y, string text, char key, Color keyColor, bool windowCentered)
        {

        }

        public static int GetWindowXCenter(this SadConsole.Console currentWindow)
        {
            return currentWindow.Width / 2;
        }

        public static int GetWindowYCenter(this SadConsole.Console currentWindow)
        {
            return currentWindow.Height / 2;
        }

        public static void TransitionFocus(this SadConsole.Console currentWindow, SadConsole.Console transitionWindow)
        {
            currentWindow.Focus();
            transitionWindow.Show();

            SadConsole.Global.CurrentScreen = transitionWindow;
        }

        public static void TransitionVisibility(this SadConsole.Console currentWindow, SadConsole.Console transitionWindow)
        {
            currentWindow.Hide();
            transitionWindow.Show();

            SadConsole.Global.CurrentScreen = transitionWindow;
        }

        public static void TransitionVisibilityAndFocus(this SadConsole.Console currentWindow, SadConsole.Console transitionWindow)
        {
            currentWindow.HideAndUnfocus();
            transitionWindow.ShowAndFocus();

            SadConsole.Global.CurrentScreen = transitionWindow;
        }

        public static void ShowAndFocus(this SadConsole.Console currentWindow)
        {
            currentWindow.IsVisible = true;
            currentWindow.IsFocused = true;
        }

        public static void HideAndUnfocus(this SadConsole.Console currentWindow)
        {
            currentWindow.IsVisible = false;
            currentWindow.IsFocused = false;
        }

        public static void Show(this SadConsole.Console currentWindow)
        {
            currentWindow.IsVisible = true;
        }

        public static void Hide(this SadConsole.Console currentWindow)
        {
            currentWindow.IsVisible = false;
        }

        public static void Focus(this SadConsole.Console currentWindow)
        {
            currentWindow.IsFocused = true;
        }

        public static void Unfocus(this SadConsole.Console currentWindow)
        {
            currentWindow.IsFocused = false;
        } 
    }
}

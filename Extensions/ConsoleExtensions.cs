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

        public static void PrintButton(this SadConsole.Console currentWindow, int x, int y, string text, char key, Color keyColor, bool windowCentered)
        {
            var str = new SadConsole.ColoredString($"[{key}] {text}");
            str[1].Foreground = keyColor;

            int _x = windowCentered ? (currentWindow.Width / 2 - (str.Count / 2)) : x;

            currentWindow.Print(_x, y, str);
        }

        public static int GetWindowXCenter(this SadConsole.Console currentWindow)
        {
            return currentWindow.Width / 2;
        }

        public static int GetWindowYCenter(this SadConsole.Console currentWindow)
        {
            return currentWindow.Height / 2;
        }

        public static void Transition(this SadConsole.Console currentWindow, SadConsole.Console transitionWindow)
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
    }
}

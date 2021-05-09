using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;


namespace NullRPG.Extensions
{
    public static class ColoredStringExtensions
    {
        public static void HighlightBackground(this ColoredString cStr, Color color)
        {
            cStr.SetBackground(color);
        }
    }
}

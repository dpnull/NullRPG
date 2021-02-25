using SadConsole;
using System;
using Console = SadConsole.Console;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace NullRPG
{
    // Todo: Add 2nd queue for message history
    public static class MessageQueue
    {
        private static readonly Queue<ColoredString> _lines = new Queue<ColoredString>();

        // Define the maximum number of lines to store
        private static int _maxLines = 1;

        // Use a Queue to keep track of the lines of text
        // The first line added to the log will also be the first removed



        /// <summary>
        /// Add a message to the log with custom message type
        /// </summary>
        /// <param name="text">The message string.</param>
        /// <param name="type">The message type</param>
        private static void Add(ColoredString str)
        {
            _lines.Enqueue(str);

            // When exceeding the maximum number of lines remove the oldest one.
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        public static void AddDefault(string message)
        {
            var str = Convert(message);
            Add(str);
        }

        public static void AddItemEquipped(string itemName)
        {
            var cStr = Convert(itemName);
            cStr.SetForeground(Color.Green);
            var message = new ColoredString("You have equipped ");
            message.SetForeground(Color.White);
            var dot = new ColoredString(".");
            dot.SetForeground(Color.White);
            message += cStr + dot;
            Add(message);
        }

        private static ColoredString Convert(string str)
        {
            return new ColoredString(str);
        }

        public static void Draw(Console console, int x = 0, int y = 0)
        {
            ColoredString[] messages = _lines.ToArray();

            foreach(var message in messages)
            {
                console.Print(x, y, message);
                y++;
            }
        }
    }
}

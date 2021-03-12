using SadConsole;
using System;
using Console = SadConsole.Console;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using NullRPG.Interfaces;
using NullRPG.GameObjects;
using System.Linq;
using NullRPG.Windows;

namespace NullRPG
{
    // Todo: Add 2nd queue for message history
    public static class MessageManager
    {
        private static readonly Queue<IMessage> _messages = new();

        // Define the maximum number of lines to store
        private static readonly int _maxLines = 1;

        // Use a Queue to keep track of the lines of text
        // The first line added to the log will also be the first removed

        public static int GetUniqueMessageId()
        {
            return MessageDatabase.GetUniqueId();
        }

        public static void AddToDatabase(IMessage message)
        {
            if (!MessageDatabase.Messages.ContainsKey(message.ObjectId))
            {
                MessageDatabase.Messages.Add(message.ObjectId, message);
            }
        }

        /// <summary>
        /// Add a message to the log with custom message type
        /// </summary>
        /// <param name="text">The message string.</param>
        /// <param name="type">The message type</param>
        private static void Add(ColoredString message)
        {
            var msg = new MessageBase(message);
            _messages.Enqueue(msg);

            // When exceeding the maximum number of lines remove the oldest one.
            if (_messages.Count > _maxLines)
            {
                _messages.Dequeue();
            }

            MessageWindow.OnMessageAdded();
        }

        public static void AddAndHighlightLast(string message, string toHighlight, Color color)
        {
            var str = new ColoredString(message);
            var toAppend = new ColoredString(toHighlight);
            toAppend.SetForeground(color);
            var dot = new ColoredString(".");

            str += toAppend + dot;
            Add(str);
        }

        public static void AddDefault(string message)
        {
            Add(new ColoredString(message));
        }

        public static void AddItemEquipped(string itemName)
        {
            AddAndHighlightLast("You have equipped ", itemName, Color.LightGreen);
        }

        public static void AddTravelled(string locationName)
        {
            AddAndHighlightLast("Arrived at ", locationName, Color.LightGreen);
        }

        public static void Draw(Console console, int x = 0, int y = 0)
        {
            IMessage[] messages = _messages.ToArray();

            foreach (var message in messages)
            {
                console.Print(x, y, message.ColoredString);
                y++;
            }
        }

        private static class MessageDatabase
        {
            public static readonly Dictionary<int, IMessage> Messages = new Dictionary<int, IMessage>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

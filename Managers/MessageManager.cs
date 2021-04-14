using Microsoft.Xna.Framework;
using NullRPG.Draw;
using NullRPG.Interfaces;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class MessageManager
    {
        private static readonly Queue<IMessage> _messages = new Queue<IMessage>();

        private static readonly int _maxLines = 1;

        public static int GetUniqueMessageId()
        {
            return MessageDatabase.GetUniqueId();
        }

        public static void AddToDictionary(IMessage message)
        {
            if (!MessageDatabase.Messages.ContainsKey(message.ObjectId))
            {
                MessageDatabase.Messages.Add(message.ObjectId, message);
            }
        }

        public static void AddMessage(string message)
        {
            Add(new ColoredString(message));
        }

        public static void AddColoredMessage(ColoredString message)
        {
            Add(message);
        }

        public static void AddItemEquipped(string itemName)
        {
            AddAndHighlightLast("You have equipped ", itemName, Color.LightGreen);
        }

        public static void AddTravelledToLocation(string locationName)
        {
            AddAndHighlightLast("Arrived at ", locationName, Color.LightGreen);
        }

        private static void AddAndHighlightLast(string message, string toHighlight, Color highlightColor)
        {
            var str = new ColoredString(message);
            var toAppend = new ColoredString(toHighlight);
            toAppend.SetForeground(highlightColor);
            var dot = new ColoredString(".");

            str += toAppend + dot;
            Add(str);
        }

        public static IMessage[] GetMessages()
        {
            return _messages.ToArray();
        }

        private static void Add(ColoredString message)
        {
            var msg = new BaseMessage(message);
            _messages.Enqueue(msg);

            if(_messages.Count > _maxLines)
            {
                _messages.Dequeue();
            }

            // add OnMessageAdded
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

using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    class MessageBase : IMessage
    {
        public int ObjectId { get; set; }
        public SadConsole.ColoredString ColoredString { get; set; }

        public MessageBase(SadConsole.ColoredString coloredString)
        {
            ObjectId = MessageManager.GetUniqueMessageId();
            MessageManager.AddToDatabase(this);

            ColoredString = coloredString;
        }
    }
}

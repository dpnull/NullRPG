using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.Managers;

namespace NullRPG.Draw
{
    public class BaseMessage : IMessage
    {
        public int ObjectId { get; set; }
        public SadConsole.ColoredString MessageString { get; set; }

        public BaseMessage(SadConsole.ColoredString messageString)
        {
            ObjectId = MessageManager.GetUniqueMessageId();
            MessageManager.AddToDictionary(this);

            MessageString = messageString;
        }
    }
}

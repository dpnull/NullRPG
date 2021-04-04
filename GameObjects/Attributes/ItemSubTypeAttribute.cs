using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Attributes
{
    class ItemSubTypeAttribute : IAttribute
    {
        public Enums.ItemSubTypes ItemSubType { get; private set; }
        public IItem Source { get; set; }
        public ItemSubTypeAttribute(IItem source)
        {
            Source = source;
        }

        public void ReceiveMessage<T>(T message)
        {
            ItemSubTypeMessage itemSubTypeMessage = message as ItemSubTypeMessage;
            if (itemSubTypeMessage != null)
            {
                ItemSubType = itemSubTypeMessage.ItemSubType;
            }
        }

    }
}

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
        public List<Enums.ItemSubTypes> ItemSubTypes { get; private set; } = new List<Enums.ItemSubTypes>();
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
                ItemSubTypes.Add(itemSubTypeMessage.ItemSubType);
            }
        }

    }
}

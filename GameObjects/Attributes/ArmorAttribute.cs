using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Attributes
{
    public class ArmorAttribute : IAttribute
    {
        public int Defense { get; private set; }

        public IItem Source { get; set; }
        public ArmorAttribute(IItem source)
        {
            Source = source;
        }

        public void ReceiveMessage<T>(T message)
        {
            ArmorMessage armorMessage = message as ArmorMessage;
            if (armorMessage != null)
            {
                Defense = armorMessage.Defense;
            }
        }
    }
}

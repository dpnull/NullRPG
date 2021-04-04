using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Attributes
{
    public class ItemSubTypeMessage
    {
        public Enums.ItemSubTypes ItemSubType { get; private set; }

        public ItemSubTypeMessage(Enums.ItemSubTypes itemSubType)
        {
            ItemSubType = itemSubType;
        }
    }
}

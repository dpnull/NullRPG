using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.ItemComponents
{
    public class ItemTypeComponentValue
    {
        public Enums.ItemTypes ItemType { get; private set; }

        public ItemTypeComponentValue(Enums.ItemTypes itemType)
        {
            ItemType = itemType;
        }
    }
}

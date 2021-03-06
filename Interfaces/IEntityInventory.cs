using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Interfaces
{
    public interface IEntityInventory
    {
        public Dictionary<int, ISlot> Slots { get; set; }

        public int GetUniqueSlotId();
    }
}

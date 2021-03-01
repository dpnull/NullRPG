using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Interfaces
{
    public interface ISlot
    {
        public int ObjectId { get; set; }
        public List<IItem> Item { get; set; }
    }
}

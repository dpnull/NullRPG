using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public class Slot : ISlot, IIndexable
    {
        public int ObjectId { get; set; }
        public List<IItem> Item { get; set; }

        public Slot(int objectId)
        {
            Item = new List<IItem>();
            ObjectId = objectId;
        }

    }
}

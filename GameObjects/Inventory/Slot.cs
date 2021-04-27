using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Inventory
{
    public class Slot : ISlot
    {
        public int ObjectId { get; set; }
        public List<IItem> Item { get; set; }

        public Slot()
        {
            ObjectId = InventoryManager.SlotDatabase.GetUniqueId();
            InventoryManager.SlotDatabase.Slots.Add(ObjectId, this);
            Item = new List<IItem>();
        }
    }
}

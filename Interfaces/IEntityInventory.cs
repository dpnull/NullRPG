using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IEntityInventory
    {
        int ObjectId { get; set; }
        public Dictionary<int, ISlot> Slots { get; set; }

        public IItem WeaponSlot { get; set; }
        public IItem HeadSlot { get; set; }
        public int GetUniqueSlotId();

    }
}

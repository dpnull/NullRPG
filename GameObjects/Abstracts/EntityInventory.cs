using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.Managers;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class EntityInventory : IEntityInventory
    {
        public int ObjectId { get; set; }
        public Dictionary<int, ISlot> Slots { get; set; }
        public IItem WeaponSlot { get; set; }
        public IItem HeadSlot { get; set; }

        public EntityInventory()
        {
            ObjectId = InventoryManager.GetUniqueId();
            InventoryManager.AddInventory(this);

            Slots = new Dictionary<int, ISlot>();
        }

        private int _currentId;

        public int GetUniqueSlotId()
        {
            return _currentId++;
        }   
    }
}


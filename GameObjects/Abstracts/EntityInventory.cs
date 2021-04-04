using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class EntityInventory : IEntityInventory
    {
        public Dictionary<int, ISlot> Slots { get; set; }
        public IItem WeaponSlot { get; set; } = new None();
        public IItem HeadSlot { get; set; } = new None();

        public EntityInventory()
        {
            Slots = new Dictionary<int, ISlot>();
        }

        private int _currentId;

        public int GetUniqueSlotId()
        {
            return _currentId++;
        }   
    }
}


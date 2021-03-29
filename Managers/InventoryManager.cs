using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Abstracts;

namespace NullRPG.Managers
{
    public static class InventoryManager
    {
        public static readonly List<IEntityInventory> EntityInventories = new List<IEntityInventory>();

        /*
         * Missing checks for when inventory size limit is reached
         */
        public const int DEFAULT_INVENTORY_SIZE = 10;

        public static int GetUniqueSlotId<T>() where T : IEntityInventory
        {
            return Get<T>().GetUniqueSlotId();
        }

        public static void Add<T>(T entityInventory) where T : IEntityInventory
        {
            EntityInventories.Add(entityInventory);
        }

        public static T Get<T>() where T : IEntityInventory
        {
            return EntityInventories.OfType<T>().SingleOrDefault();
        }

        public static void AddSlot<T>(ISlot slot) where T : IEntityInventory
        {
            if (!Get<T>().Slots.ContainsKey(slot.ObjectId))
            {
                Get<T>().Slots.Add(slot.ObjectId, slot);
            }
        }
    }
}

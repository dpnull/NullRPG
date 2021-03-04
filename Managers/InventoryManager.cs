using NullRPG.GameObjects;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullRPG.Managers
{
    public static class InventoryManager
    {
        /*
         * Missing checks for when inventory size limit is reached
         */
        public const int DEFAULT_INVENTORY_SIZE = 10;

        public static int GetUniqueId()
        {
            return SlotDatabase.GetUniqueId();
        }

        public static void AddSlot(ISlot slot)
        {
            if (!SlotDatabase.Slots.ContainsKey(slot.ObjectId))
            {
                SlotDatabase.Slots.Add(slot.ObjectId, slot);
            }
        }

        public static void AddToInventory(IItem item)
        {
            var freeSlot = SlotDatabase.Slots.FirstOrDefault(f => !f.Value.Item.Any());

            // if true, get the first available slot.
            if (item.IsUnique)
            {
                SlotDatabase.Slots[freeSlot.Key].Item.Add(item);
            }
            else
            {
                // get the first slot with matching item name to passed item in the item list and add it.
                if (SlotDatabase.Slots.Values.Any(i => i.Item.Any(j => j.Name.ToString() == item.Name.ToString())))
                {
                    foreach (var slot in SlotDatabase.Slots)
                    {
                        if (slot.Value.Item.Any(i => i.Name.ToString() == item.Name.ToString()))
                        {
                            slot.Value.Item.Add(item);
                        }
                    }
                }
                else
                {
                    // If no existing non-unique item in the slots exists, use up the next available slot.
                    if (freeSlot.Value.Item.All(i => i.Name.ToString() != item.Name.ToString()))
                    {
                        SlotDatabase.Slots[freeSlot.Key].Item.Add(item);
                    }
                }
            }
        }

        public static void CreateDefault()
        {
            // create the inventory
            while (SlotDatabase.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {
                AddSlot(new Slot());
            }
        }

        // Get an array of T based on the criteria passed, otherwise pass the exact array copy of dictionary.
        public static T[] GetSlots<T>(Func<T, bool> criteria = null) where T : ISlot
        {
            var collection = SlotDatabase.Slots.Values.ToArray().OfType<T>();
            if (criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }


            return collection.ToArray();
        }

        public static T GetSlot<T>(int objectId) where T : ISlot
        {
            var collection = SlotDatabase.Slots.ToArray();
            foreach (var item in collection)
            {
                return (T)SlotDatabase.Slots.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static void RemoveSlotItem(int objectId)
        {
            var removable = SlotDatabase.Slots[objectId].Item.First();
            SlotDatabase.Slots[objectId].Item.Remove(removable);
            // If the deleted weapon was equipped, change the player's weapon to "None"
            if (Game.GameSession.Player.CurrentWeapon.ObjectId == objectId)
            {
                Game.GameSession.Player.CurrentWeapon = (ItemTypes.WeaponItem)ItemManager.GetItem<IItem>(0);
            }
        }

        private static class SlotDatabase
        {
            public static readonly Dictionary<int, ISlot> Slots = new Dictionary<int, ISlot>();

            private static int _currentId;
            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

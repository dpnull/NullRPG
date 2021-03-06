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

        public static int GetUniqueSlotId(IEntityInventory inventory)
        {
            return inventory.GetUniqueSlotId();
        }

        public static void AddSlot<T>(T inventory, ISlot slot) where T : IEntityInventory
        {

            if (!inventory.Slots.ContainsKey(slot.ObjectId))
            {
                inventory.Slots.Add(slot.ObjectId, slot);
            }
        }

        public static void AddToInventory<T>(IEntityInventory inventory, IItem item) where T : IEntityInventory
        {
            var freeSlot = inventory.Slots.FirstOrDefault(f => !f.Value.Item.Any());

            // if true, get the first available slot.
            if (item.IsUnique)
            {
                inventory.Slots[freeSlot.Key].Item.Add(item);
            }
            else
            {
                // get the first slot with matching item name to passed item in the item list and add it.
                if (inventory.Slots.Values.Any(i => i.Item.Any(j => j.Name.ToString() == item.Name.ToString())))
                {
                    foreach (var slot in inventory.Slots)
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
                        inventory.Slots[freeSlot.Key].Item.Add(item);
                    }
                }
            }
        }

        public static void CreateDefault<T>(T inventory) where T : IEntityInventory
        {
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {   
                AddSlot(inventory, new Slot(inventory.GetUniqueSlotId()));
            }
        }

        // Get an array of T based on the criteria passed, otherwise pass the exact array copy of dictionary.
        public static T[] GetSlots<T>(IEntityInventory inventory, Func<T, bool> criteria = null) where T : ISlot
        {
            var collection = inventory.Slots.Values.ToArray().OfType<T>();
            if (criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }


            return collection.ToArray();
        }

        public static T GetSlot<T>(IEntityInventory inventory, int objectId) where T : ISlot
        {
            var collection = inventory.Slots.ToArray();
            foreach (var item in collection)
            {
                return (T)inventory.Slots.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static void RemoveSlotItem(IEntityInventory inventory, int objectId)
        {
            var removable = inventory.Slots[objectId].Item.First();
            inventory.Slots[objectId].Item.Remove(removable);
            // If the deleted weapon was equipped, change the player's weapon to "None"
            if (Game.GameSession.Player.CurrentWeapon.ObjectId == objectId)
            {
                Game.GameSession.Player.CurrentWeapon = (ItemTypes.WeaponItem)ItemManager.GetItem<IItem>(0);
            }
        }
    }
}

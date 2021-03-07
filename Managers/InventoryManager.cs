using NullRPG.GameObjects;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static void EquipWeapon<T>(int itemObjectId) where T : IEntityInventory
        {
            var inventory = Get<T>();
            var item = ItemManager.GetItem<IItem>(itemObjectId);
            if (item != null && item is not MiscItem)
            {
                var equippable = ItemManager.GetItem<IItem>(itemObjectId);
                inventory.CurrentWeapon = (WeaponItem)equippable;
            }
        }

        public static IItem GetEquippedItem<T>(Type itemType) where T : IEntityInventory
        {
            if(itemType == typeof(WeaponItem))
            {
                return Get<T>().CurrentWeapon;
            } else if (itemType == typeof(HeadItem))
            {
                return Get<T>().CurrentHeadItem;
            } else if (itemType == typeof(BodyItem))
            {
                return Get<T>().CurrentBodyItem;
            } else if (itemType == typeof(LegsItem))
            {
                return Get<T>().CurrentLegsItem;
            }
            else
            {
                return null;
            }
        }



        public static void AddToInventory<T>(IItem item) where T : IEntityInventory
        {
            var inventory = Get<T>();
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

        public static void CreateDefault<T>() where T : IEntityInventory
        {
            var inventory = Get<PlayerInventory>();
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {   
                AddSlot<IEntityInventory>(new Slot(inventory.GetUniqueSlotId()));
            }
        }

        // Get an array of T based on the criteria passed, otherwise pass the exact array copy of dictionary.
        public static ISlot[] GetSlots<T>(Func<ISlot, bool> criteria = null) where T : IEntityInventory
        {
            var collection = Get<T>().Slots.Values.ToArray().OfType<ISlot>();
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
            if (Game.GameSession.Player.Inventory.CurrentWeapon.ObjectId == objectId)
            {
                Game.GameSession.Player.Inventory.CurrentWeapon = (ItemTypes.WeaponItem)ItemManager.GetItem<IItem>(0);
            }
        }
    }
}

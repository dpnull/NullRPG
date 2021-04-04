using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Attributes;
using NullRPG.GameObjects.Entity;
using NullRPG.GameObjects;

namespace NullRPG.Managers
{
    public static class InventoryManager
    {
        public static readonly List<IEntityInventory> EntityInventories = new List<IEntityInventory>();

        /*
         * Missing checks for when inventory size limit is reached
         */
        public const int DEFAULT_INVENTORY_SIZE = 10;

        public static void CreateDefault<T>() where T : IEntityInventory
        {
            var inventory = Get<PlayerInventory>();
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {
                AddSlot<IEntityInventory>(new Slot(inventory.GetUniqueSlotId()));
            }
        }

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

        public static T GetSlot<T>(IEntityInventory inventory, int objectId) where T : ISlot
        {
            var collection = inventory.Slots.ToArray();
            foreach (var item in collection)
            {
                return (T)inventory.Slots.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
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

        public static void AddSlot<T>(ISlot slot) where T : IEntityInventory
        {
            if (!Get<T>().Slots.ContainsKey(slot.ObjectId))
            {
                Get<T>().Slots.Add(slot.ObjectId, slot);
            }
        }
        
        public static void EquipItem<T>(int itemObjectId) where T : IEntityInventory
        {
            var inventory = Get<T>();
            var item = ItemManager.GetItem<IItem>(itemObjectId);
            var equipped = GetEquippedItems<IEntityInventory>();
            if (item is not null /*&& item is not MiscItem*/)
            {
                if (equipped.All(i => i.ObjectId != item.ObjectId))
                {
                    if (item.ItemType is Enums.ItemTypes.Weapon) { inventory.WeaponSlot = item; }
                    else if (AttributeManager.GetItemSubType(item) == AttributeManager.GetItemSubType(inventory.HeadSlot))
                    {
                        inventory.HeadSlot = item;
                    }
                    //MessageManager.AddItemEquipped(item.Name);
                }
                else
                {
                    //MessageManager.AddDefault("You have already equipped this item.");
                }
            }
        }

        public static void AddToInventory<T>(IItem item) where T : IEntityInventory
        {
            var inventory = Get<T>();
            var freeSlot = inventory.Slots.FirstOrDefault(f => !f.Value.Item.Any());
            inventory.Slots[freeSlot.Key].Item.Add(item);
            /*
            // if true, gets the first available slot
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
            */
        }

        public static IItem GetEquippedItem<T>(Enums.InventorySlotTypes slotType) where T : IEntityInventory
        {
            if (slotType == Enums.InventorySlotTypes.Weapon)
            {
                return Get<T>().WeaponSlot;
            }
            else if (slotType == Enums.InventorySlotTypes.Head)
            {
                return Get<T>().HeadSlot;
            }
            /*
            else if (itemType == typeof(BodyItem))
            {
                return Get<T>().CurrentBodyItem;
            }
            else if (itemType == typeof(LegsItem))
            {
                return Get<T>().CurrentLegsItem;
            }
            */
            else
            {
                return null;
            }
        }

        public static IItem[] GetEquippedItems<T>() where T : IEntityInventory
        {
            IItem[] items =
            {
                Get<T>()?.WeaponSlot,
                Get<T>()?.HeadSlot
                //Get<T>()?.CurrentBodyItem,
                //Get<T>()?.CurrentLegsItem
            };

            return items;
        }
    }
}

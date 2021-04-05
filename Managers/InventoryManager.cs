using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;
using NullRPG.GameObjects.Entity;
using NullRPG.GameObjects;
using NullRPG.GameObjects.Components.Entity;

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
            return InventoryDatabase.GetUniqueId();
        }

        public static void CreateDefault<T>(T inventory) where T : IEntityInventory
        {
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {
                AddSlot<IEntityInventory>(inventory, new Slot(inventory.GetUniqueSlotId()));
            }
        }

        public static int GetUniqueSlotId<T>(T inventory) where T : IEntityInventory
        {
            return GetInventoryByObjectId<T>(inventory.ObjectId).GetUniqueSlotId();
        }

        public static void AddInventory<T>(T entityInventory) where T : IEntityInventory
        {
            if (!InventoryDatabase.Inventories.ContainsKey(entityInventory.ObjectId))
            {
                InventoryDatabase.Inventories.Add(entityInventory.ObjectId, entityInventory);
            }
        }

        public static T GetInventoryByObjectId<T>(int objectId) where T : IEntityInventory
        {
            var collection = InventoryDatabase.Inventories.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)InventoryDatabase.Inventories.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            throw new System.Exception($"Inventory does not exist. {nameof(objectId)}_{objectId}");
        }

        public static IEntityInventory GetEntityInventory<T>(T entity) where T : IEntity
        {
            if (entity != null)
            {
                var inventory = entity.GetComponent<InventoryComponent>().Inventory;
                return inventory;
            }

            return default;
        }

        public static T GetInventorySlot<T>(IEntity entity, int objectId) where T : ISlot
        {
            var inventory = GetEntityInventory(entity);
            var collection = inventory.Slots.ToArray();
            foreach (var item in collection)
            {
                return (T)inventory.Slots.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        // Get an array of T based on the criteria passed, otherwise pass the exact array copy of dictionary.
        public static ISlot[] GetSlots<T>(T entity, Func<ISlot, bool> criteria = null) where T : IEntity
        {
            var inventory = GetEntityInventory(entity);
            var collection = GetInventoryByObjectId<IEntityInventory>(inventory.ObjectId).Slots.Values.ToArray().OfType<ISlot>();
            if (criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }

            return collection.ToArray();
        }

        public static void AddSlot<T>(T inventory, ISlot slot) where T : IEntityInventory
        {
            if (!GetInventoryByObjectId<T>(inventory.ObjectId).Slots.ContainsKey(slot.ObjectId))
            {
                GetInventoryByObjectId<T>(inventory.ObjectId).Slots.Add(slot.ObjectId, slot);
            }
        }
        
        public static void EquipItem<T>(T inventory, int itemObjectId) where T : IEntityInventory
        {
            var item = ItemManager.GetItem<IItem>(itemObjectId);
            var equipped = GetEquippedItems<IEntityInventory>(inventory);
            if (item is not null /*&& item is not MiscItem*/)
            {
                if (equipped.All(i => i.ObjectId != item.ObjectId))
                {
                    if (item.ItemType is Enums.ItemCategories.Weapon) { inventory.WeaponSlot = item; }
                    else if (ComponentManager.ContainsItemSubType<IItem>(item, Enums.ItemTypes.HeadArmor))
                    {
                        inventory.HeadSlot = item;
                    }
                    //ComponentValueManager.AddItemEquipped(item.Name);
                }
                else
                {
                    //ComponentValueManager.AddDefault("You have already equipped this item.");
                }
            }
        }

        public static void AddToInventory<T>(T entity, IItem item) where T : IEntity
        {
            var inventory = GetEntityInventory(entity);
            var freeSlot = inventory.Slots.FirstOrDefault(f => !f.Value.Item.Any());

            // if true, get the first available slot.
            if (!item.IsStackable)
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

        public static IItem GetEquippedItem<T>(T inventory, Enums.InventorySlotTypes slotType) where T : IEntityInventory
        {
            if (slotType == Enums.InventorySlotTypes.Weapon)
            {
                return GetInventoryByObjectId<T>(inventory.ObjectId).WeaponSlot;
            }
            else if (slotType == Enums.InventorySlotTypes.Head)
            {
                return GetInventoryByObjectId<T>(inventory.ObjectId).HeadSlot;
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

        public static IItem[] GetEquippedItems<T>(T inventory) where T : IEntityInventory
        {
            IItem[] items =
            {
                GetInventoryByObjectId<T>(inventory.ObjectId)?.WeaponSlot,
                GetInventoryByObjectId<T>(inventory.ObjectId)?.HeadSlot
                //Get<T>()?.CurrentBodyItem,
                //Get<T>()?.CurrentLegsItem
            };

            return items;
        }

        private static class InventoryDatabase
        {
            public static readonly Dictionary<int, IEntityInventory> Inventories = new Dictionary<int, IEntityInventory>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

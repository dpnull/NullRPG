using NullRPG.GameObjects;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Components.Item;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Add a number of slots based on the DEFAULT_INVENTORY_SIZE constant to the passed inventory.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="inventory">An entity inventory.</param>
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

        /// <summary>
        /// Adds an inventory to the InventoryDatabase.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="entityInventory">An entity inventory to be added.</param>
        public static void AddInventory<T>(T entityInventory) where T : IEntityInventory
        {
            if (!InventoryDatabase.Inventories.ContainsKey(entityInventory.ObjectId))
            {
                InventoryDatabase.Inventories.Add(entityInventory.ObjectId, entityInventory);
            }
        }

        /// <summary>
        /// Gets an entity inventory with an id that matches the passed objectId.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="objectId">An id of the object to look for in the database.</param>
        /// <returns>An entity inventory with matching id.</returns>
        public static T GetInventoryByObjectId<T>(int objectId) where T : IEntityInventory
        {
            var collection = InventoryDatabase.Inventories.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)InventoryDatabase.Inventories.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            throw new System.Exception($"Inventory does not exist. {nameof(objectId)}_{objectId}");
        }

        /// <summary>
        /// Gets an existing entity inventory from the passed entity.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntity interface.</typeparam>
        /// <param name="entity">An entity with an existing entity inventory.</param>
        /// <returns></returns>
        public static IEntityInventory GetEntityInventory<T>(T entity) where T : IEntity
        {
            if (entity != null)
            {
                var inventory = entity.GetComponent<InventoryComponent>().Inventory;
                return inventory;
            }

            return default;
        }

        /// <summary>
        /// Gets an inventory slot with matching objectId from the passed entity.
        /// </summary>
        /// <typeparam name="T">A type that inherits from ISlot interface.</typeparam>
        /// <param name="entity">An entity with an existing and instantiated entity inventory.</param>
        /// <param name="objectId">>An id of the object to look for in the database.</param>
        /// <returns>A slot of type ISlot with the matching id.</returns>
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

        /// <summary>
        /// Get an array of IEntity based on the criteria passed, otherwise pass the exact array copy of dictionary.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntity interface.</typeparam>
        /// <param name="entity">An entity with an existing and instantiated entity inventory.</param>
        /// <param name="criteria">Additional search constraints. Leave empty if none.</param>
        /// <returns>A constrainted array collection of slots. Returns all entity inventory slots if criteria is left null.</returns>
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

        /// <summary>
        /// Adds a slot to an already existing entity inventory.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="inventory">An entity inventory.</param>
        /// <param name="slot">A slot to be added to the entity inventory.</param>
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
            var equipped = GetEquippedItems(inventory);
            if (item is not null)
            {
                if(ComponentManager.ContainsComponent<ItemPropertyComponent>(item.ObjectId) && ComponentManager.ContainsItemProperty(item, Enums.ItemProperties.Equippable))
                {
                    // check if no equipped item matches id of passed item.
                    if (equipped.All(i => i.ObjectId != item.ObjectId))
                    {
                        if (item.ItemCategory is Enums.ItemCategories.Weapon) { inventory.WeaponSlot = item; }
                        if (ComponentManager.ContainsItemType<IItem>(item, Enums.ItemTypes.HeadArmor))
                        {
                            inventory.HeadSlot = item;
                        }
                        if (ComponentManager.ContainsItemType(item, Enums.ItemTypes.ChestArmor))
                        {
                            inventory.ChestSlot = item;
                        }
                        if (ComponentManager.ContainsItemType(item, Enums.ItemTypes.LegsArmor))
                        {
                            inventory.LegsSlot = item;
                        }
                        MessageManager.AddItemEquipped(item.Name);
                    }
                    else
                    {
                        MessageManager.AddMessage("You are already wearing this item. [???]");
                    }
                    // TODO: Add message log message displaying that this item cannot be equipped.
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
            switch (slotType)
            {
                case Enums.InventorySlotTypes.Weapon:
                    return GetInventoryByObjectId<T>(inventory.ObjectId).WeaponSlot;
                case Enums.InventorySlotTypes.Head:
                    return GetInventoryByObjectId<T>(inventory.ObjectId).HeadSlot;
                case Enums.InventorySlotTypes.Chest:
                    return GetInventoryByObjectId<T>(inventory.ObjectId).ChestSlot;
                case Enums.InventorySlotTypes.Legs:
                    return GetInventoryByObjectId<T>(inventory.ObjectId).LegsSlot;
                default:
                    break;
            }

            return default; // should do more
        }

        public static IItem[] GetEquippedItems<T>(T inventory) where T : IEntityInventory
        {
            IItem[] items =
            {
                GetInventoryByObjectId<T>(inventory.ObjectId)?.WeaponSlot,
                GetInventoryByObjectId<T>(inventory.ObjectId)?.HeadSlot,
                GetInventoryByObjectId<T>(inventory.ObjectId)?.ChestSlot,
                GetInventoryByObjectId<T>(inventory.ObjectId)?.LegsSlot
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
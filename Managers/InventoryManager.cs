using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Inventory;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class InventoryManager
    {
        private const int DEFAULT_INVENTORY_SIZE = 10;

        public static int GetUniqueEntityInventoryId()
        {
            return EntityInventoryDatabase.GetUniqueId();
        }

        /// <summary>
        /// Gets an entity inventory with an id that matches the passed objectId.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="objectId">An id of the object to look for in the database.</param>
        /// <returns>An entity inventory with matching id.</returns>
        public static T GetEntityInventoryByObjectId<T>(int objectId) where T : IEntityInventory
        {
            var collection = EntityInventoryDatabase.EntityInventories.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)EntityInventoryDatabase.EntityInventories.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            throw new System.Exception($"Inventory does not exist. {nameof(objectId)}_{objectId}");
        }

        /// <summary>
        /// Gets an existing entity inventory from the passed entity.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntity interface.</typeparam>
        /// <param name="entity">An entity with an existing entity inventory.</param>
        /// <returns></returns>
        public static IEntityInventory GetEntityInventory<T>(T entity) where T : IComponentSystemEntity
        {
            if (entity != null)
            {
                var inventory = entity.GetComponent<EntityComponents.Inventory>();
                return inventory.EntityInventory;
            }

            return default;
        }

        /// <summary>
        /// Add a number of slots based on the DEFAULT_INVENTORY_SIZE constant to the passed inventory.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="inventory">An entity inventory.</param>
        public static void CreateDefaultInventory<T>(T inventory) where T : IEntityInventory
        {
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {
                AddSlot<IEntityInventory>(inventory, new Slot());
            }
        }

        /// <summary>
        /// Adds an inventory to the InventoryDatabase.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="entityInventory">An entity inventory to be added.</param>
        public static void AddInventory<T>(T entityInventory) where T : IEntityInventory
        {
            if (!EntityInventoryDatabase.EntityInventories.ContainsKey(entityInventory.ObjectId))
            {
                EntityInventoryDatabase.EntityInventories.Add(entityInventory.ObjectId, entityInventory);
            }
        }

        /// <summary>
        /// Adds a slot to an already existing entity inventory.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IEntityInventory interface.</typeparam>
        /// <param name="inventory">An entity inventory.</param>
        /// <param name="slot">A slot to be added to the entity inventory.</param>
        public static void AddSlot<T>(T inventory, ISlot slot) where T : IEntityInventory
        {
            if (!GetEntityInventoryByObjectId<T>(inventory.ObjectId).Slots.ContainsKey(slot.ObjectId))
            {
                GetEntityInventoryByObjectId<T>(inventory.ObjectId).Slots.Add(slot.ObjectId, slot);
            }
        }

        /// <summary>
        /// Gets an inventory slot with matching objectId from the passed entity.
        /// </summary>
        /// <typeparam name="T">A type that inherits from ISlot interface.</typeparam>
        /// <param name="entity">An entity with an existing and instantiated entity inventory.</param>
        /// <param name="objectId">>An id of the object to look for in the database.</param>
        /// <returns>A slot of type ISlot with the matching id.</returns>
        public static ISlot GetInventorySlot<T>(T entity, int objectId) where T : IComponentSystemEntity
        {
            var inventory = GetEntityInventory(entity);
            var collection = inventory.Slots.ToArray();
            foreach (var item in collection)
            {
                return inventory.Slots.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static ISlot[] GetInventorySlots<T>(T entity) where T : IComponentSystemEntity
        {
            var inventory = GetEntityInventory(entity);
            return inventory.Slots.Values.ToArray();
        }

        public static void AddToInventory<T>(T entity, IItem item) where T : IComponentSystemEntity
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

        public static class EntityInventoryDatabase
        {
            public static readonly Dictionary<int, IEntityInventory> EntityInventories = new Dictionary<int, IEntityInventory>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }

        public static class SlotDatabase
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

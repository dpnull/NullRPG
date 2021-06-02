using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static NullRPG.Enums;

namespace NullRPG.Managers
{
    public class EntityManager
    {
        public static int GetUniqueId()
        {
            return EntityDatabase.GetUniqueId();
        }

        // START SORT OUT 



        // END SORT OUT

        // directly add to the database
        public static void Add(IEntity entity)
        {
            if (!EntityDatabase.Entities.ContainsKey(entity.ObjectId))
            {
                EntityDatabase.Entities.Add(entity.ObjectId, entity);
            }
        }

        /// <summary>
        /// Returns
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public static T Get<T>(int objectId) where T : IEntity
        {
            var collection = ECSManager.Get<T>();
            foreach (var entity in collection)
            {
                return collection.SingleOrDefault(e => e.ObjectId == objectId);
            }

            return default;
        }

        public static IArea GetEntityArea<T>(T entity) where T : IEntity
        {
            if (entity.HasComponent<EntityComponents.WorldPosition>())
            {
                var area = entity.GetComponent<EntityComponents.WorldPosition>().Area;
                return area;
            }

            throw new SystemException($"{nameof(entity)} missing PositionComponent");
        }

        public static T Create<T>() where T : IEntity, new()
        {
            T entity = new();

            Add(entity);

            return entity;
        }

        public static IItem[] GetEquippedItems<T>(T entity) where T : IEntity
        {
            var equipment = entity.GetComponent<EntityComponents.Equipment>();

            return equipment.GetEquippedSlotItems().ToArray();
        }

        public static void EquipItem<T>(T entity, int itemObjectId) where T : IEntity
        {
            var item = ItemManager.Get<IItem>(itemObjectId);
            var equipped = GetEquippedItems(entity);
            if (item is not null)
            {
                if (item.HasComponent<ItemComponents.EquippableComponent>())
                {
                    // check if no equipped item matches id of passed item.
                    if (equipped.All(i => i.ObjectId != item.ObjectId))
                    {
                        entity.GetComponent<EntityComponents.Equipment>().EquipItem(item);
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

        public static void ChangeEntityPosition<T>(T entity, PositionTypes positionType, int positionObjectId) where T : IEntity
        {
            var entityPosition = entity.GetComponent<EntityComponents.WorldPosition>();

            var currentArea = entityPosition.Area;
            var currentWorld = entityPosition.World;

            if (positionType is PositionTypes.Location)
            {
                if (currentArea.Locations.ContainsKey(positionObjectId))
                {
                    entityPosition.Location = LocationManager.Get<ILocation>(positionObjectId);
                    MessageManager.AddTravelledToLocation(entityPosition.Location.Name);
                }
                else
                {
                    throw new Exception($"Location with id_{positionObjectId} does not exist.");
                }
            }
            else if (positionType is PositionTypes.Area)
            {
                if (currentWorld.Areas.ContainsKey(positionObjectId))
                {
                    entityPosition.Area = AreaManager.Get<IArea>(positionObjectId);
                    entityPosition.Location = AreaManager.Get<IArea>(positionObjectId).Locations.Values.FirstOrDefault();
                    // Add message travelled
                }
                else
                {
                    throw new Exception($"Area with id_{positionObjectId} does not exist.");
                }
            }
            else if (positionType is PositionTypes.World)
            {
                if (currentWorld.ObjectId != WorldManager.GetWorld<IWorld>(positionObjectId).ObjectId)
                {
                    entityPosition.World = WorldManager.GetWorld<IWorld>(positionObjectId);
                }
                else
                {
                    throw new Exception($"World with id_{positionObjectId} does not exist.");
                }
            }
            else
            {
                throw new SystemException("Invalid position type");
            }
        }

        public static class EntityDatabase
        {
            public static readonly Dictionary<int, IEntity> Entities = new Dictionary<int, IEntity>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }


        }
    }
}

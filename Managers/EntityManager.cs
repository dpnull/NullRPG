using NullRPG.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Managers
{
    public static class EntityManager
    {
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
            var collection = EntityDatabase.Entities.ToArray();
            foreach (var entity in collection)
            {
                return (T)EntityDatabase.Entities.Values.SingleOrDefault(e => e.ObjectId == objectId);
            }

            return default;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="location"></param>
        public static void AddEntityToLocation<T>(T entity, ILocation location) where T : IEntity
        {
            var worlds = WorldManager.GetWorlds();
            foreach(var world in worlds)
            {
               // if(world.Areas.)
            }
        }

        public static T Create<T>() where T : IEntity, new()
        {
            T entity = new();

            Add(entity);

            return entity;
        }

        public static int GetUniqueId()
        {
            return EntityDatabase.GetUniqueId();
        }

        private static class EntityDatabase
        {
            public static readonly Dictionary<int, IEntity> Entities = new();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}
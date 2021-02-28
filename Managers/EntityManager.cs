using NullRPG.GameObjects;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        // define a constraint to instantiate a generic type
        public static T Create<T>() where T : IEntity, new()
        {
            T entity = new T();

            return entity;
        }

        public static int GetUniqueId()
        {
            return EntityDatabase.GetUniqueId();
        }

        private static class EntityDatabase
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

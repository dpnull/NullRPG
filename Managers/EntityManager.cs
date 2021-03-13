using NullRPG.GameObjects;
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

        public static T Get<T>(int objectId) where T : IEntity
        {
            var collection = EntityDatabase.Entities.ToArray();
            foreach (var entity in collection)
            {
                return (T)EntityDatabase.Entities.Values.SingleOrDefault(e => e.ObjectId == objectId);
            }

            return default;
        }

        // define a constraint to instantiate a generic type
        public static T Create<T>() where T : IEntity, new()
        {
            T entity = new();

            Add(entity);

            return entity;
        }

        public static void TravelEntityToArea(Player player, int objectId)
        {
            var area = AreaManager.GetAreaByObjectId<IArea>(objectId);

            if (player.CurrentArea != area)
            {
                player.CurrentArea = (Area)area;
                MessageManager.AddTravelled(area.Name);
            }
            else
            {
                MessageManager.AddDefault("You are already in this area.");
            }
        }

        public static void TravelEntityToLocation(IEntity entity, int objectId)
        {
            var location = LocationManager.GetLocationByObjectId<ILocation>(objectId);
            if (entity.CurrentLocation != location)
            {
                entity.CurrentLocation = (Location)location;
                MessageManager.AddTravelled(location.Name);
            }
            else
            {
                MessageManager.AddDefault("You are already at this location.");
            }
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
using NullRPG.GameObjects;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class WorldObjectManager
    {
        public static int GetUniqueWorldObjectId()
        {
            return WorldObjectDatabase.GetUniqueId();
        }

        public static void AddWorldObject(IWorldObject worldObject)
        {
            if (!WorldObjectDatabase.WorldObjects.ContainsKey(worldObject.ObjectId))
            {
                WorldObjectDatabase.WorldObjects.Add(worldObject.ObjectId, worldObject);
            }
        }

        public static T GetWorldObjectByObjectId<T>(int objectId) where T : IWorldObject
        {
            var collection = WorldObjectDatabase.WorldObjects.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)WorldObjectDatabase.WorldObjects.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }
            return default;
        }

        public static T[] GetLocationWorldObjectsByObjectType<T>(ILocation location, WorldObjectBase.Objects objectType) where T : IWorldObject
        {
            var collection = GetLocationWorldObjects<T>(location).Where(o => o.ObjectType == objectType).ToArray().OfType<T>();
            return collection.ToArray();
        }

        public static bool ContainsWorldObject<T>(T location, WorldObjectBase.Objects objectType) where T : ILocation
        {
            var collection = LocationManager.GetLocationByObjectId<T>(location.ObjectId).WorldObjects;
            if(collection != null)
            {
                foreach (var worldObject in collection)
                {
                    if (worldObject != null)
                    {
                        if (worldObject.ObjectType == objectType)
                        {
                            return true;
                        }
                    }
                }
            }


            return false;
        }

        public static T[] GetLocationWorldObjects<T>(ILocation location) where T : IWorldObject
        {
            if (LocationManager.GetLocationByObjectId<ILocation>(location.ObjectId).WorldObjects != null)
            {
                var collection = LocationManager.GetLocationByObjectId<ILocation>(location.ObjectId).WorldObjects.ToArray().OfType<T>();
                return collection.ToArray();
            }

            return default;
        }

        public static class WorldObjectDatabase
        {
            public static readonly Dictionary<int, IWorldObject> WorldObjects = new Dictionary<int, IWorldObject>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

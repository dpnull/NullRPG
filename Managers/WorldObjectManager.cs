﻿using NullRPG.GameObjects;
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

        public static bool ContainsWorldObject<T>(T location, WorldObjectBase.Objects objectType) where T : ILocation
        {
            var collection = LocationManager.GetLocationByObjectId<T>(location.ObjectId);
            if (collection.WorldObjects != null)
            {
                foreach (var worldObject in collection.WorldObjects)
                {
                    if (worldObject.ObjectType == objectType)
                    {
                        return true;
                    }
                }
            }

            return false;
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

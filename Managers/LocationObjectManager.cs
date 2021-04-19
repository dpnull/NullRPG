using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class LocationObjectManager
    {
        public static int GetUniqueLocationObjectId()
        {
            return LocationObjectDatabase.GetUniqueId();
        }

        public static void AddLocationObject(ILocationObject locationObject)
        {
            if (!LocationObjectDatabase.LocationObjects.ContainsKey(locationObject.ObjectId))
            {
                LocationObjectDatabase.LocationObjects.Add(locationObject.ObjectId, locationObject);
            }
        }

        public static T GetLocationObjectById<T>(int objectId) where T : ILocationObject
        {
            var collection = LocationObjectDatabase.LocationObjects.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)LocationObjectDatabase.LocationObjects.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }
            return default;
        }

        public static class LocationObjectDatabase
        {
            public static readonly Dictionary<int, ILocationObject> LocationObjects = new Dictionary<int, ILocationObject>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

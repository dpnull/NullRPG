using NullRPG.Interfaces;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class LocationManager
    {
        public static int GetUniqueLocationId()
        {
            return LocationDatabase.GetUniqueId();
        }

        // called automatically when creating a new item
        public static void AddLocation(ILocation location)
        {
            if (!LocationDatabase.Locations.ContainsKey(location.ObjectId))
            {
                LocationDatabase.Locations.Add(location.ObjectId, location);
            }
        }

        public static string GetLocationName<T>() where T : ILocation
        {
            return LocationDatabase.Locations.OfType<T>().SingleOrDefault().Name;
        }

        public static T GetLocationByObjectId<T>(int objectId) where T : ILocation
        {
            var collection = LocationDatabase.Locations.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)LocationDatabase.Locations.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }
            return default;
        }

        public static T[] GetAllLocations<T>() where T : ILocation
        {
            var collection = LocationDatabase.Locations.Values.ToArray().OfType<T>();
            return collection.ToArray();
        }

        public static ColoredString GetLocationName<T>(int objectId) where T : ILocation
        {
            var location = GetLocationByObjectId<ILocation>(objectId);

            ColoredString locName = new ColoredString(location.Name);

            return locName;
        }

        public static class LocationDatabase
        {
            public static readonly Dictionary<int, ILocation> Locations = new Dictionary<int, ILocation>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

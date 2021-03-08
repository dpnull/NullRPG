using NullRPG.Interfaces;
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
        public static void Add(ILocation location)
        {
            if (!LocationDatabase.Locations.ContainsKey(location.ObjectId))
            {
                LocationDatabase.Locations.Add(location.ObjectId, location);
            }
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

using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class AreaManager
    {
        public static int GetUniqueAreaId()
        {
            return AreaDatabase.GetUniqueId();
        }


        public static T Get<T>(int objectId) where T : IArea
        {
            var collection = AreaDatabase.Areas.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)AreaDatabase.Areas.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static void AddLocationToArea<T, U>(T area, U location) where T : IArea where U : ILocation
        {
            var collection = GetAreaLocations<U>(area);
            if (!collection.Contains(location))
            {
                area.Locations.Add(location.ObjectId, location);
            }
        }

        public static ILocation[] GetAreaLocations<T>(IArea area) where T : ILocation
        {
            return AreaManager.Get<IArea>(area.ObjectId).Locations.Values.ToArray();
        }

        public static void AddArea(IArea area)
        {
            if (!AreaDatabase.Areas.ContainsKey(area.ObjectId))
            {
                AreaDatabase.Areas.Add(area.ObjectId, area);
            }
        }

        private static class AreaDatabase
        {
            public static readonly Dictionary<int, IArea> Areas = new Dictionary<int, IArea>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

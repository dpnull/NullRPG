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

        public static T Get<T>(int objectId) where T : IArea
        {
            var collection = ECSManager.Get<T>();
            foreach (var item in collection)
            {
                return collection.SingleOrDefault(i => i.ObjectId == objectId);
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
    }
}

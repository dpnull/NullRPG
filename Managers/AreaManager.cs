using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Components.Entity;

namespace NullRPG.Managers
{
    public static class AreaManager
    {
        public static void AddArea(IArea area)
        {
            if (!AreaDatabase.Areas.ContainsKey(area.ObjectId))
            {
                AreaDatabase.Areas.Add(area.ObjectId, area);
            }
        }

        public static void AddLocationToArea<T>(T area, ILocation location) where T : IArea
        {
            if (!area.Locations.ContainsKey(location.ObjectId))
            {
                area.Locations.Add(location.ObjectId, location);
            }
        }

        public static int GetUniqueAreaId()
        {
            return AreaDatabase.GetUniqueId();
        }

        public static T GetAreaByObjectId<T>(int objectId) where T : IArea
        {
            var collection = AreaDatabase.Areas.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)AreaDatabase.Areas.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static T GetEntityArea<T>(IEntity entity) where T : IArea
        {
            if (ComponentManager.ContainsEntityComponent<PositionComponent>(entity.ObjectId))
            {
                var area = entity.GetComponent<PositionComponent>().Area;
                return (T)area;
            }

            throw new SystemException($"{nameof(entity)} missing PositionComponent");
        }

        public static T[] GetAllAreas<T>() where T : IArea
        {
            var collection = AreaDatabase.Areas.Values.ToArray().OfType<T>();
            return collection.ToArray();
        }

        // Unneeded?
        public static T[] GetWorldAreas<T>(IWorld world) where T : IArea
        {
            return default;
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

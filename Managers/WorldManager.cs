using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class WorldManager
    {

        // To check
        public static void AddAreaToWorld<T, U>(T world, U area) where T : IWorld where U : IArea
        {
            var collection = GetWorldAreas<U>(world);
            if (!collection.Contains(area))
            {
                world.Areas.Add(area.ObjectId, area);
            }
        }

        public static IArea[] GetWorldAreas<T>(IWorld world)
        {
            return GetWorld<IWorld>(world.ObjectId).Areas.Values.ToArray();
        }

        public static T GetWorld<T>(int objectId) where T : IWorld
        {
            var collection = ECSManager.Get<T>();
            foreach (var item in collection)
            {
                return collection.SingleOrDefault(w => w.ObjectId == objectId);
            }

            return default;
        }

        public static T[] GetWorlds<T>() where T : IWorld
        {
            return ECSManager.Get<T>();
        }

        private static class WorldDatabase
        {
            public static readonly Dictionary<int, IWorld> Worlds = new Dictionary<int, IWorld>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

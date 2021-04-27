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
        public static int GetUniqueId()
        {
            return WorldDatabase.GetUniqueId();
        }

        public static void AddWorld<T>(T world) where T : IWorld
        {
            if (!WorldDatabase.Worlds.ContainsKey(world.ObjectId))
            {
                WorldDatabase.Worlds.Add(world.ObjectId, world);
            }
        }

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
            var collection = WorldDatabase.Worlds.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)WorldDatabase.Worlds.Values.SingleOrDefault(w => w.ObjectId == objectId);
            }

            return default;
        }

        public static IWorld[] GetWorlds()
        {
            return WorldDatabase.Worlds.Values.ToArray();
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

using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects;
using NullRPG.GameObjects.Worlds;

namespace NullRPG.Managers
{
    // Currently called WorldManager, as there will be other world instances eg. dungeon.
    public static class WorldManager
    {
        public static readonly List<IWorld> Worlds = new List<IWorld>();


        public static void AddArea<T>(IArea area) where T : IWorld
        {
            var world = Get<T>();

            world.Areas.Add(area.ObjectId, area);
        }

        public static int GetUniqueAreaId()
        {
            return AreaDatabase.GetUniqueId();
        }

        public static void Add<T>(T world) where T : IWorld
        {
            Worlds.Add(world);
        }

        public static T Get<T>() where T : IWorld
        {
            return Worlds.OfType<T>().SingleOrDefault();
        }

        public static IArea[] GetWorldAreas<T>(Func<IArea, bool> criteria = null) where T : IWorld
        {
            var collection = Get<T>().Areas.ToArray().OfType<IArea>();
            if(criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }
            return collection.ToArray();
        }

        public static class AreaDatabase
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

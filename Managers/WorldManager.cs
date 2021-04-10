using NullRPG.GameObjects.Components.Entity;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class WorldManager
    {
        public static void AddWorld<T>(T world) where T : IWorld
        {
            if (!WorldDatabase.Worlds.ContainsKey(world.ObjectId))
            {
                WorldDatabase.Worlds.Add(world.ObjectId, world);
            }
        }

        public static T GetWorld<T>(int objectId) where T : IWorld
        {
            var collection = WorldDatabase.Worlds.Values.ToArray();
            foreach(var item in collection)
            {
                return (T)WorldDatabase.Worlds.Values.SingleOrDefault(w => w.ObjectId == objectId);
            }

            return default;
        }

        public static void AddAreaToWorld<T>(T world, IArea area) where T : IWorld
        {
            if (!world.Areas.ContainsKey(area.ObjectId))
            {
                world.Areas.Add(area.ObjectId, area);
            }
        }

        public static T GetEntityWorld<T>(IEntity entity) where T : IWorld
        {
            if (ComponentManager.ContainsEntityComponent<PositionComponent>(entity.ObjectId))
            {
                var world = entity.GetComponent<PositionComponent>().World;
                return (T)world;
            }

            throw new SystemException($"{nameof(entity)} missing PositionComponent");
        }

        public static IWorld[] GetWorlds()
        {
            return WorldDatabase.Worlds.Values.ToArray();
        }

        public static int GetUniqueId()
        {
            return WorldDatabase.GetUniqueId();
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

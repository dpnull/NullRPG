using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects;
using NullRPG.GameObjects.Worlds;
using static NullRPG.Managers.AreaManager;

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



        public static void AddWorld<T>(T world) where T : IWorld
        {
            Worlds.Add(world);
        }

        public static T Get<T>() where T : IWorld
        {
            return Worlds.OfType<T>().SingleOrDefault();
        }

        public static IArea GetWorldArea<T>(string areaName) where T : IWorld
        {
            var world = Get<T>();

            foreach(var area in world.Areas)
            {
                if(area.Value.Name == areaName)
                {
                    return AreaManager.Get<IArea>(area.Value.ObjectId);
                }
            }

            return default;
        }

        /*
        public static IArea GetArea<T>(int objectId) where T : IArea
        {
            var collection = AreaManager.GetAreas<IArea>();
            foreach(var area in collection)
            {
                if(area.ObjectId == objectId)
                {
                    return AreaManager.Get<IArea>(objectId);
                }
                
            }

            return default;
        }
        */

        public static IArea[] GetWorldAreas<T>(Func<IArea, bool> criteria = null) where T : IWorld
        {
            var collection = Get<T>().Areas.ToArray().OfType<IArea>();
            if(criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }
            return collection.ToArray();
        }



    }
}

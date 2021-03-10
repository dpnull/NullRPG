﻿using NullRPG.Interfaces;
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

        /// <summary>
        /// Takes the passed area and adds it to the passed world type.
        /// </summary>
        /// <typeparam name="T">World type.</typeparam>
        /// <param name="area">Area to add.</param>
        public static void AddArea<T>(IArea area) where T : IWorld
        {
            var world = Get<T>();

            world.Areas.Add(area.ObjectId, area);
        }

        /// <summary>
        /// Takes IWorld type and adds it to the list of IWorld types.
        /// </summary>
        /// <typeparam name="T">Must by IWorld type..</typeparam>
        /// <param name="world">The world to be added.</param>
        public static void AddWorld<T>(T world) where T : IWorld
        {
            Worlds.Add(world);
        }

        /// <summary>
        /// Retrevies IWorld from 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : IWorld
        {
            return Worlds.OfType<T>().SingleOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="areaName"></param>
        /// <returns></returns>
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

            /// <summary>
            /// Creates an IArea array of the passed type based on the criteria provided. If none are provided, returns all areas from the collection.
            /// </summary>
            /// <typeparam name="T">Object implementing the IWorld interface.</typeparam>
            /// <param name="criteria">The condition to evaluate.</param>
            /// <returns>Returns an array collection of areas from the passed World object.</returns>
        public static IArea[] GetWorldAreas<T>(Func<IArea, bool> criteria = null) where T : IWorld
        {
            var collection = Get<T>().Areas.Values.ToArray().OfType<IArea>();
            if(criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }
            return collection.ToArray();
        }

            

    }
}

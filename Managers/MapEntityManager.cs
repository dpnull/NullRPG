using Microsoft.Xna.Framework;
using NullRPG.GameObjects;
using NullRPG.Interfaces;
using NullRPG.Map;
using SadConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Managers
{
    public static class MapEntityManager
    {
        /// <summary>
        /// Returns a new entity or null, if the position is already taken.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <param name="grid">Custom grid, for tests</param>
        /// <returns></returns>
        public static T Create<T>(Point position, int blueprintId, MapGrid grid = null) where T : IMapEntity
        {
            if (MapEntityExistsAt(position, blueprintId))
            {
                return default;
            }

            T entity;
            if (grid != null)
            {
                entity = (T)Activator.CreateInstance(typeof(T), grid);
                entity.Position = position;
                entity.MoveToBlueprint(blueprintId);
            }
            else
            {
                entity = Activator.CreateInstance<T>();
                entity.Position = position;
                entity.MoveToBlueprint(blueprintId);
            }

            MapEntityDatabase.MapEntities.Add(entity.ObjectId, entity);
            return entity;
        }

        public static T GetMapEntityAt<T>(Point position, int blueprintId) where T : IMapEntity
        {
            return (T)MapEntityDatabase.MapEntities.Values.SingleOrDefault(e => e.Position == position && e.CurrentBlueprintId == blueprintId);
        }

        public static T GetMapEntityAt<T>(int x, int y, int blueprintId) where T : IMapEntity
        {
            return (T)MapEntityDatabase.MapEntities.Values.SingleOrDefault(e => e.Position.X == x && e.Position.Y == y && e.CurrentBlueprintId == blueprintId);
        }

        public static bool MapEntityExistsAt(Point position, int blueprintId)
        {
            return GetMapEntityAt<IMapEntity>(position, blueprintId) != null;
        }

        public static bool MapEntityExistsAt(int x, int y, int blueprintId)
        {
            return GetMapEntityAt<IMapEntity>(x, y, blueprintId) != null;
        }

        public static void RecalculatFieldOfView(IMapEntity entity, bool redrawFov = true, bool exploreCells = false)
        {
            var mapPositionComponent = entity.GetComponent<EntityComponents.MapPosition>();
            mapPositionComponent.FieldOfView.Calculate(mapPositionComponent.Position, mapPositionComponent.FieldOfViewRadius);
            if (entity is Player && redrawFov)
                GridManager.Grid.DrawFieldOfView(entity);
        }

        public static void RecalculatFieldOfView()
        {
            // Recalculate the fov of all entities
            var entities = GetMapEntities<IMapEntity>();
            foreach (var entity in entities)
            {
                entity.FieldOfView.Calculate(entity.Position, entity.FieldOfViewRadius);
                if (entity is Player)
                    GridManager.Grid.DrawFieldOfView(entity);
            }
        }

        public static T[] GetMapEntities<T>(Func<T, bool> criteria = null) where T : IMapEntity
        {
            var collection = MapEntityDatabase.MapEntities.Values.ToArray().OfType<T>();
            if (criteria != null)
            {
                collection = collection.Where(criteria.Invoke);
            }
            return collection.ToArray();
        }

        private static class MapEntityDatabase
        {
            public static readonly Dictionary<int, IMapEntity> MapEntities = new Dictionary<int, IMapEntity>();

            private static int _currentId;
            public static int GetUniqueId()
            {
                return _currentId++;
            }

            public static void Reset()
            {
                MapEntities.Clear();
                _currentId = 0;
            }

            public static void ResetExcept(params int[] ids)
            {
                var toRemove = new List<int>();
                foreach (var entity in MapEntities)
                {
                    toRemove.Add(entity.Key);
                }

                toRemove = toRemove.Except(ids).ToList();
                foreach (var id in toRemove)
                    MapEntities.Remove(id);

                _currentId = MapEntities.Count == 0 ? 0 : (MapEntities.Max(a => a.Key) + 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class ECSManager
    {
        public static int GetUniqueId()
        {
            return ECSDatabase.GetUniqueId();
        }

        public static void AddEntity<T>(T entity) where T : IComponentSystemEntity
        {
            if (!ECSDatabase.Entities.ContainsKey(entity.ObjectId))
            {
                ECSDatabase.Entities.Add(entity.ObjectId, entity);
            }
        }

        public static T[] Get<T>() where T : IComponentSystemEntity
        {
            return ECSDatabase.Entities.Values.OfType<T>().ToArray();
        }

        static class ECSDatabase
        {
            public static Dictionary<int, IComponentSystemEntity> Entities = new Dictionary<int, IComponentSystemEntity>();
            private static int _currentId;
            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

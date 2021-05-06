using NullRPG.GameObjects;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class ItemManager
    {

        public static T Get<T>(int objectId) where T : IItem
        {
            var collection = ECSManager.Get<T>();
            foreach (var item in collection)
            {
                return collection.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static T[] GetAll<T>() where T : IItem
        {
            return ECSManager.Get<T>();
        }
    }
}

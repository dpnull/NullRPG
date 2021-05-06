using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class LocationObjectManager
    {
        public static T Get<T>(int objectId) where T : ILocationObject
        {
            var collection = ECSManager.Get<T>();
            foreach (var item in collection)
            {
                return collection.SingleOrDefault(i => i.ObjectId == objectId);
            }
            return default;
        }

        public static void AddItemToLocationObject<T>(T locationObject, IItem item) where T : ILocationObject
        {
            if (locationObject.HasComponent<EntityComponents.Inventory>())
            {
                InventoryManager.AddToInventory((IComponentSystemEntity)locationObject, item);
            }
        }
    }
}

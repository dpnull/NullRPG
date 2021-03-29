using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class ItemManager
    {
        public static int GetUniqueId()
        {
            return ItemDatabase.GetUniqueId();
        }

        public static void CreateItems()
        {

        }

        public static void Add(IItem item)
        {
            if (!ItemDatabase.Items.ContainsKey(item.ObjectId))
            {
                ItemDatabase.Items.Add(item.ObjectId, item);
            }
        }

        public static T GetItem<T>(int objectId) where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray().OfType<T>();
            foreach (var item in collection)
            {
                return (T)ItemDatabase.Items.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static class ItemDatabase
        {
            public static readonly Dictionary<int, IItem> Items = new Dictionary<int, IItem>();

            private static int _currentId;

            public static int GetUniqueId()
            {
                return _currentId++;
            }
        }
    }
}

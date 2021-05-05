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
        public static int GetUniqueId()
        {
            return ItemDatabase.GetUniqueId();
        }

        public static void Add<T>(T item) where T : IItem
        {
            if (!ItemDatabase.Items.ContainsKey(item.ObjectId))
            {
                ItemDatabase.Items.Add(item.ObjectId, item);
            }
        }

        public static T Get<T>(int objectId) where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)ItemDatabase.Items.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static List<T> GetAll<T>() where T : IItem
        {
            return ItemDatabase.Items.Values.OfType<T>().ToList();
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

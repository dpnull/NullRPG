using NullRPG.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Managers
{
    public static class ItemManager
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

        /// <summary>
        /// Searches the ItemDatabase for an IItem object matching the passed objectId.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IItem interface.</typeparam>
        /// <returns>An IItem object with matching objectId.</returns>
        public static T GetItem<T>(int objectId) where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray();
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
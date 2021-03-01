using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullRPG.Managers
{
    public static class ItemManager
    {
        public static int GetUniqueId()
        {
            return ItemDatabase.GetUniqueId();
        }

        // called automatically when creating a new item
        public static void Add(IItem item)
        {
            if (!ItemDatabase.Items.ContainsKey(item.ObjectId))
            {
                ItemDatabase.Items.Add(item.ObjectId, item);
            }
        }

        public static void Remove(IItem item)
        {
            // Don't remove id 1 which is reveserved for "None" weapon item
            if (Game.GameSession.Player.CurrentWeapon.ObjectId == item.ObjectId)
            {
                Game.GameSession.Player.EquipWeapon(GetItem<IItem>(0).ObjectId);
            }
            ItemDatabase.Items.Remove(item.ObjectId);
        }

        public static T[] GetItems<T>() where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray().OfType<T>();
            return collection.ToArray();
        }

        public static T GetItem<T>(int objectId) where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)ItemDatabase.Items.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }
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

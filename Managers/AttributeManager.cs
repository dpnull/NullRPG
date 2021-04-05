using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.Managers
{
    public static class AttributeManager
    {
        public static Enums.ItemSubTypes[] GetItemSubTypes<T>(T item) where T : IItem
        {
            return ItemManager.GetItem<T>(item.ObjectId).GetAttribute<ItemSubTypeAttribute>().ItemSubTypes.ToArray();
        }
        public static void PrintWeapon<T>(int objectId, T attributeType)
        {
            var item = ItemManager.GetItem<IItem>(objectId);
        }

        /// <summary>
        /// Returns true if passed item contains component of type T.
        /// </summary>
        /// <typeparam name="T">IAttribute type parameter.</typeparam>
        /// <param name="objectId">Item object id.</param>
        /// <returns></returns>
        public static bool ContainsAttribute<T>(int objectId) where T : IAttribute
        {
            var item = ItemManager.GetItem<IItem>(objectId);

            if (item.Components.OfType<T>().Any())
                return true;
            return false;
        }

        public static bool ContainsItemSubType<T>(T item, Enums.ItemSubTypes itemSubType) where T : IItem
        {
            return true && GetItemSubTypes(item).Contains(itemSubType);

        }

    }
}

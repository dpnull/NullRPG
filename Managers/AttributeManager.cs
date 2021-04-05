using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Components.ItemComponents;

namespace NullRPG.Managers
{
    public static class ComponentManager
    {
        public static Enums.ItemTypes[] GetItemSubTypes<T>(T item) where T : IItem
        {
            return ItemManager.GetItem<T>(item.ObjectId).GetComponent<ItemTypeComponent>().ItemTypes.ToArray();
        }
        public static void PrintWeapon<T>(int objectId, T attributeType)
        {
            var item = ItemManager.GetItem<IItem>(objectId);
        }

        /// <summary>
        /// Returns true if passed item contains component of type T.
        /// </summary>
        /// <typeparam name="T">IComponent type parameter.</typeparam>
        /// <param name="objectId">Item object id.</param>
        /// <returns></returns>
        public static bool ContainsComponent<T>(int objectId) where T : IComponent
        {
            var item = ItemManager.GetItem<IItem>(objectId);

            if (item.Components.OfType<T>().Any())
                return true;
            return false;
        }

        public static bool ContainsItemSubType<T>(T item, Enums.ItemTypes itemSubType) where T : IItem
        {
            return true && GetItemSubTypes(item).Contains(itemSubType);

        }

    }
}

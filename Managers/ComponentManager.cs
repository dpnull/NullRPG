using NullRPG.GameObjects.Components.Item;
using NullRPG.Interfaces;
using System;
using System.Linq;

namespace NullRPG.Managers
{
    public static class ComponentManager
    {
        /// <summary>
        /// Returns sub types from the ItemTypeComponent for the passed Item object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IItem interface.</typeparam>
        /// <param name="item">An objects that inherits from IItem interface.</param>
        /// <returns>An array of sub types for the passed IItem object.</returns>
        public static Enums.ItemTypes[] GetItemSubTypes<T>(T item) where T : IItem
        {
            return ItemManager.GetItem<T>(item.ObjectId).GetComponent<ItemTypeComponent>().ItemTypes.ToArray();
        }

        /// <summary>
        /// Returns true if passed item contains component of type T.
        /// </summary>
        /// <typeparam name="T">IComponent type parameter.</typeparam>
        /// <param name="objectId">Item object id.</param>
        /// <returns></returns>
        public static bool ContainsComponent<T>(int objectId) where T : IItemComponent
        {
            var item = ItemManager.GetItem<IItem>(objectId);

            if (item.Components.OfType<T>().Any())
                return true;
            return false;
        }

        /// <summary>
        /// Checks if passed item contains component of a named constant from ItemTypes enum.
        /// </summary>
        /// <typeparam name="T">A type that inherits from IItem interface.</typeparam>
        /// <param name="item">An object that inherits from IItem interface.</param>
        /// <param name="itemSubType">A named constant from ItemTypes enum.</param>
        /// <returns>Returns true if IItem object contains the passed itemSubType.</returns>
        public static bool ContainsItemSubType<T>(T item, Enums.ItemTypes itemSubType) where T : IItem
        {
            return true && GetItemSubTypes(item).Contains(itemSubType);
        }
    }
}
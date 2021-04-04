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
        public static Enums.ItemSubTypes GetItemSubType<T>(T item) where T : IItem
        {
            return ItemManager.GetItem<T>(item.ObjectId).GetAttribute<ItemSubTypeAttribute>().ItemSubType;
        }
        public static void PrintWeapon<T>(int objectId, T attributeType)
        {
            var item = ItemManager.GetItem<IItem>(objectId);
        }

    }
}

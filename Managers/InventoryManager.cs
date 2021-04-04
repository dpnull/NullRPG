using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.Managers
{
    public static class InventoryManager
    {
        public static readonly List<IEntityInventory> EntityInventories = new List<IEntityInventory>();

        /*
         * Missing checks for when inventory size limit is reached
         */
        public const int DEFAULT_INVENTORY_SIZE = 10;

        public static int GetUniqueSlotId<T>() where T : IEntityInventory
        {
            return Get<T>().GetUniqueSlotId();
        }

        public static void Add<T>(T entityInventory) where T : IEntityInventory
        {
            EntityInventories.Add(entityInventory);
        }

        public static T Get<T>() where T : IEntityInventory
        {
            return EntityInventories.OfType<T>().SingleOrDefault();
        }

        public static void AddSlot<T>(ISlot slot) where T : IEntityInventory
        {
            if (!Get<T>().Slots.ContainsKey(slot.ObjectId))
            {
                Get<T>().Slots.Add(slot.ObjectId, slot);
            }
        }
        
        public static void EquipItem<T>(int itemObjectId) where T : IEntityInventory
        {
            var inventory = Get<T>();
            var item = ItemManager.GetItem<IItem>(itemObjectId);
            var equipped = GetEquippedItems<IEntityInventory>();
            if (item is not null /*&& item is not MiscItem*/)
            {
                if (equipped.All(i => i.ObjectId != item.ObjectId))
                {
                    if (item.ItemType is Enums.ItemTypes.Weapon) { inventory.WeaponSlot = item; }
                    else if (AttributeManager.GetItemSubType(item) == AttributeManager.GetItemSubType(inventory.HeadSlot))
                    {
                        inventory.HeadSlot = item;
                    }
                    //MessageManager.AddItemEquipped(item.Name);
                }
                else
                {
                    //MessageManager.AddDefault("You have already equipped this item.");
                }
            }
        }
        public static IItem GetEquippedItem<T>(Enums.InventorySlotTypes slotType) where T : IEntityInventory
        {
            if (slotType == Enums.InventorySlotTypes.Weapon)
            {
                return Get<T>().WeaponSlot;
            }
            else if (slotType == Enums.InventorySlotTypes.Head)
            {
                return Get<T>().HeadSlot;
            }
            /*
            else if (itemType == typeof(BodyItem))
            {
                return Get<T>().CurrentBodyItem;
            }
            else if (itemType == typeof(LegsItem))
            {
                return Get<T>().CurrentLegsItem;
            }
            */
            else
            {
                return null;
            }
        }

        public static IItem[] GetEquippedItems<T>() where T : IEntityInventory
        {
            IItem[] items =
            {
                Get<T>()?.WeaponSlot,
                Get<T>()?.HeadSlot
                //Get<T>()?.CurrentBodyItem,
                //Get<T>()?.CurrentLegsItem
            };

            return items;
        }
    }
}

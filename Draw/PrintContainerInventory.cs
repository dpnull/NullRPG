using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Attributes;
using NullRPG.GameObjects.Entity;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Draw
{
    public class PrintContainerInventory : PrintContainerBase
    {
        public PrintContainerInventory(IIndexedKeybinding[] keybindings) : base(keybindings)
        {
            CreateEquipped(keybindings);
        }

        public void CreateEquipped(IIndexedKeybinding[] keybindings)
        {
            foreach(var item in keybindings)
            {
                var slotItem = InventoryManager.GetSlot<ISlot>(InventoryManager.Get<PlayerInventory>(), item.ObjectId).Item.FirstOrDefault();
                ColoredString itemName = new ColoredString(slotItem.Name);

                PrintContainerValue itemNameVal = new PrintContainerValue(itemName, 0);

                // checks if item id matches equipped item id
                if(slotItem.ObjectId == InventoryManager.GetEquippedItem<PlayerInventory>(Enums.InventorySlotTypes.Head).ObjectId)
                {
                    itemName.SetBackground(new Color(18, 77, 7));
                }

                string itemType = slotItem?.GetAttribute<ItemSubTypeAttribute>().ItemSubType.ToString();

                PrintContainerValue itemTypeVal = new PrintContainerValue(new ColoredString(itemType), 20);

                string itemId = $"slotId_{item.ObjectId}  itemId_{slotItem.ObjectId}";

                PrintContainerValue itemIdVal = new PrintContainerValue(new ColoredString(itemId), 30);

                PrintContainerItem containerItem = new PrintContainerItem(new List<PrintContainerValue> { itemNameVal, itemTypeVal, itemIdVal });
                ContainerItems.Add(containerItem);
            }
        }

        public void Draw(SadConsole.Console console, int y = 0)
        {
            int _y = y;
            foreach(var item in ContainerItems)
            {
                foreach(var value in item.ItemValues)
                {
                    console.Print(value.Offset, _y, value.ColoredString);
                }
                _y++;
            }
        }
    }
}

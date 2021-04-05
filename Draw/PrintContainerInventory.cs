using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Attributes;
using NullRPG.GameObjects.Entity;
using NullRPG.Input;
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
            int _index = 0;
            foreach(var item in keybindings)
            {
                var slotItem = InventoryManager.GetSlot<ISlot>(InventoryManager.Get<PlayerInventory>(), item.ObjectId).Item.FirstOrDefault();
                ColoredString itemName = new ColoredString(slotItem.Name);

                PrintContainerValue itemNameVal = new PrintContainerValue(itemName, 4);

                // checks if item id matches equipped item id
                if(slotItem.ObjectId == InventoryManager.GetEquippedItem<PlayerInventory>(Enums.InventorySlotTypes.Head).ObjectId)
                {
                    itemName.SetBackground(new Color(18, 77, 7));
                }

                Button = new ButtonIndex(keybindings[_index].Key, Color.Green, Color.White, 0, 0, true);
                _index++;
                PrintContainerValue buttonValue = new PrintContainerValue(new ColoredString(Button.Key.ToString()), 0);

                string itemType = slotItem.GetAttribute<ItemSubTypeAttribute>().ItemSubTypes.FirstOrDefault().ToString();

                PrintContainerValue itemTypeVal = new PrintContainerValue(new ColoredString(itemType), 20);

                string itemId = $"slotId_{item.ObjectId}  itemId_{slotItem.ObjectId}";

                PrintContainerValue itemIdVal = new PrintContainerValue(new ColoredString(itemId), 30);

                PrintContainerValue quantity;
                var slot = InventoryManager.GetSlot<ISlot>(InventoryManager.Get<PlayerInventory>(), item.ObjectId);
                if (slot.Item.FirstOrDefault().IsStackable)
                {
                    quantity = new PrintContainerValue(new ColoredString($"count: {slot.Item.Count}"), 50);
                } else
                {
                    quantity = new PrintContainerValue(new ColoredString($"\0"), 50); // temporary
                }

                PrintContainerItem containerItem = new PrintContainerItem(new List<PrintContainerValue> { buttonValue, itemNameVal, itemTypeVal, itemIdVal, quantity });
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

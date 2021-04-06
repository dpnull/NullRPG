using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Components.Item;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Draw
{
    public class PrintContainerInventory : PrintContainerBase
    {
        /// <summary>
        /// Create an automated container for drawing of an entity inventory.
        /// </summary>
        /// <param name="inventory">Entity inventory.</param>
        /// <param name="keybindings">An already instatiated keybindings array.</param>
        public PrintContainerInventory(IEntityInventory inventory, IIndexedKeybinding[] keybindings) : base(keybindings)
        {
            CreateEquipped(inventory, keybindings);
        }

        /// <summary>
        /// Build a dynamic drawing method for the passed objects of type IEntityInventory.
        /// </summary>
        /// <param name="inventory">Passed entity inventory from the constructor.</param>
        /// <param name="keybindings">Passed keybindings array from the constructor.</param>
        public void CreateEquipped(IEntityInventory inventory, IIndexedKeybinding[] keybindings)
        {
            int _index = 0;
            foreach (var item in keybindings)
            {
                var slotItem = InventoryManager.GetInventorySlot<ISlot>(Game.GameSession.Player, item.ObjectId).Item.FirstOrDefault();
                ColoredString itemName = new ColoredString(slotItem.Name);

                PrintContainerValue itemNameVal = new PrintContainerValue(itemName, 4);

                // checks if item id matches equipped item id
                if (slotItem.ObjectId == InventoryManager.GetEquippedItem<IEntityInventory>(inventory, Enums.InventorySlotTypes.Head).ObjectId)
                {
                    itemName.SetBackground(new Color(18, 77, 7));
                }

                Button = new ButtonIndex(keybindings[_index].Key, Color.Green, Color.White, 0, 0, true);
                _index++;
                PrintContainerValue buttonValue = new PrintContainerValue(new ColoredString(Button.Key.ToString()), 0);

                string itemType = slotItem.GetComponent<ItemTypeComponent>().ItemTypes.FirstOrDefault().ToString();

                PrintContainerValue itemTypeVal = new PrintContainerValue(new ColoredString(itemType), 20);

                string itemId = $"slotId_{item.ObjectId}  itemId_{slotItem.ObjectId}";

                PrintContainerValue itemIdVal = new PrintContainerValue(new ColoredString(itemId), 30);

                PrintContainerValue quantity;
                var slot = InventoryManager.GetInventorySlot<ISlot>(Game.GameSession.Player, item.ObjectId);
                if (slot.Item.FirstOrDefault().IsStackable)
                {
                    quantity = new PrintContainerValue(new ColoredString($"count: {slot.Item.Count}"), 50);
                }
                else
                {
                    quantity = new PrintContainerValue(new ColoredString($"\0"), 50); // temporary
                }

                PrintContainerItem containerItem = new PrintContainerItem(new List<PrintContainerValue> { buttonValue, itemNameVal, itemTypeVal, itemIdVal, quantity });
                ContainerItems.Add(containerItem);
            }
        }

        /// <summary>
        /// Draw the container.
        /// </summary>
        /// <param name="console">Console window to be drawn from.</param>
        /// <param name="y">Starting y coordinate.</param>
        public void Draw(SadConsole.Console console, int y = 0)
        {
            int _y = y;
            foreach (var item in ContainerItems)
            {
                foreach (var value in item.ItemValues)
                {
                    console.Print(value.Offset, _y, value.ColoredString);
                }
                _y++;
            }
        }
    }
}
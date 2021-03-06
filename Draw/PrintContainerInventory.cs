﻿using Microsoft.Xna.Framework;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using NullRPG.Extensions;

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
                var slotItem = InventoryManager.GetInventorySlot(Game.GameSession.Player, item.ObjectId).Item.FirstOrDefault();

                // Name & Quantity
                ColoredString itemName = new ColoredString($"{slotItem.Name}");
                PrintContainerValue itemNameVal;
                var slot = InventoryManager.GetInventorySlot(Game.GameSession.Player, item.ObjectId);
                if (slot.Item.FirstOrDefault().IsStackable)
                {
                    itemNameVal = new PrintContainerValue(new ColoredString($"{slotItem.Name} x{slot.Item.Count}"), 4);
                }
                else
                {
                    itemNameVal = new PrintContainerValue(new ColoredString($"{slotItem.Name}"), 4);
                }



                // Highlight equipped items
                foreach (var equippedItem in EntityManager.GetEquippedItems(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId)))
                {
                    if (equippedItem.ObjectId == slotItem.ObjectId)
                    {
                        itemName.HighlightBackground(new Color(18, 77, 7));
                    }
                }

                // Button
                Button = new Button(keybindings[_index].Key.ToString(), 0, 0, keybindings[_index].Key, Color.Green, Color.White, Color.Black, false, true);
                _index++;
                Button.DrawNumericOnly(true);
                PrintContainerValue buttonValue = new PrintContainerValue(Button.GetFormattedButton(), 0);

                // Item type
                // string itemType = slotItem.ItemCategory.ToName();
                // PrintContainerValue itemTypeVal = new PrintContainerValue(new ColoredString(itemType), 20);

                // Item id
                //string itemId = $"slotId_{item.ObjectId}  itemId_{slotItem.ObjectId}";
                //PrintContainerValue itemIdVal = new PrintContainerValue(new ColoredString(itemId), 30);



                PrintContainerItem containerItem = new PrintContainerItem(new List<PrintContainerValue> { buttonValue, itemNameVal });
                ContainerItems.Add(containerItem);
            }
        }

        /// <summary>
        /// Draw the container.
        /// </summary>
        /// <param name="console">Console window to be drawn from.</param>
        /// <param name="y">Starting y coordinate.</param>
        public void Draw(SadConsole.Console console,     int y = 0)
        {
            int _y = y;
            foreach (var item in ContainerItems)
            {
                foreach (var value in item.ItemValues)
                {
                    if (value != null)
                    {
                        console.Print(value.Offset, _y, value.ColoredString);
                    }
                }
                _y++;
            }
        }
    }
}
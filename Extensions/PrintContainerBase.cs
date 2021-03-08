using Microsoft.Xna.Framework;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Extensions
{
    public class PrintContainerBase
    {
        public int YOffset { get; private set; } = 0;
        public int XOffset { get; private set; } = 0;
        public int IndexOffset { get; private set; } = 0;
        public int NameOffset { get; private set; } = 4;
        public int TypeOffset { get; private set; } = 20;

        private readonly List<PrintContainerBase> _printable;
        public ColoredString Name { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public string Id { get; set; }
        public ButtonIndex ButtonIndex { get; set; }

        public enum ListType
        {
            Inventory,
            Equipped
        }

        public PrintContainerBase(IIndexedKeybinding[] keybindings, ListType type)
        {
            _printable = new List<PrintContainerBase>();
            if(type is ListType.Inventory)
            {
                CreateInventory(keybindings);
            } else
            {
                CreateEquipped(keybindings);
            }
            
        }

        public PrintContainerBase()
        {
        }

        public void SetPrintingOffsets(int xOffset, int yOffset, int typeOffset)
        {
            YOffset = yOffset;
            IndexOffset = xOffset;
            NameOffset = xOffset + 4;
            TypeOffset = xOffset + typeOffset;
        }

        public void RawSetPrintingOffsets(int xOffset, int yOffset, int indexOffset, int nameOffset, int typeOffset)
        {
            XOffset = xOffset;
            YOffset = yOffset;
            IndexOffset = xOffset + indexOffset;
            NameOffset = xOffset + nameOffset;
            TypeOffset = xOffset + typeOffset;
        }

        public void CreateEquipped(IIndexedKeybinding[] keybindings)
        {
            int index = 0;
            var equippedItems = InventoryManager.GetEquippedItems<PlayerInventory>();
            foreach(var item in keybindings)
            {
                ColoredString prefix = new ColoredString(); 
                var equippedItem = ItemManager.GetItem<IItem>(equippedItems[index].ObjectId);

                ColoredString itemName = ItemManager.GetItemName<IItem>(equippedItem.ObjectId);

                // temporary solution for item type formatting specifically for this window
                string itemType = equippedItem.GetType() == typeof(WeaponItem) ? "[WEAPON]" :
                                equippedItem.GetType() == typeof(HeadItem) ? "[HEAD]" :
                                equippedItem.GetType() == typeof(BodyItem) ? "[BODY]" :
                                equippedItem.GetType() == typeof(LegsItem) ? "[LEGS]" : "UNKNOWN";

                string itemId = $"itemId_{equippedItem.ObjectId}";

                var printableItem = new PrintContainerBase()
                {
                    Name = itemName,
                    Type = itemType,
                    Data = "\0",
                    Id = "\0",
                    ButtonIndex = new ButtonIndex(keybindings[index].Keybinding, Color.Green, Color.White, 0, 0, true)
                };

                _printable.Add(printableItem);
                index++;
            }
        }

        public void CreateInventory(IIndexedKeybinding[] keybindings)
        {
            int index = 0; // for keybinding index
            foreach (var item in keybindings)
            {
                var slotItem = InventoryManager.GetSlot<ISlot>(InventoryManager.Get<PlayerInventory>(), item.Object.ObjectId).Item.FirstOrDefault();
                ColoredString itemName = ItemManager.GetItemName<IItem>(slotItem.ObjectId);

                if (slotItem is MiscItem)
                {
                    itemName += $" x{InventoryManager.GetSlot<ISlot>(Game.GameSession.Player.Inventory, item.Object.ObjectId).Item.Count}";
                }

                // temp
                if(slotItem is not MiscItem)
                {
                    var equippedItemId = InventoryManager.GetEquippedItem<PlayerInventory>(slotItem.GetType()).ObjectId;
                    if (slotItem.ObjectId == equippedItemId)
                    {
                        itemName.SetBackground(new Color(18, 77, 7));
                    }
                }

                // retrieves the description attribute from the class
                string itemType = slotItem?.GetType().GetCustomAttribute<DescriptionAttribute>(false).Description;
                string itemId = $"slotId_{InventoryManager.GetSlot<ISlot>(Game.GameSession.Player.Inventory, item.Object.ObjectId).ObjectId}, itemId_{slotItem.ObjectId}";

                var printableItem = new PrintContainerBase()
                {
                    Name = itemName,
                    Type = itemType,
                    Data = "\0",
                    Id = "\0",
                    ButtonIndex = new ButtonIndex(keybindings[index].Keybinding, Color.Green, Color.White, 0, 0, true)
                };

                _printable.Add(printableItem);
                index++;
            }
        }

        public void Print(SadConsole.Console console)
        {
            int _y = YOffset;
            foreach (var str in _printable)
            {
                str.ButtonIndex.Draw(IndexOffset, _y, console);
                console.Print(NameOffset, _y, str.Name);
                console.Print(TypeOffset, _y, str.Type);
                //console.Print(DATA_OFFSET, _y, str.Data);
                //console.Print(ID_OFFSET, _y, str.Id);
                _y++;
            }
        }
    }
}

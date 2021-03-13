using Microsoft.Xna.Framework;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

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
            Equipped,
            Areas,
            Locations
        }

        public PrintContainerBase(IIndexedKeybinding[] keybindings, ListType type)
        {
            _printable = new List<PrintContainerBase>();
            if (type is ListType.Inventory)
            {
                CreateInventory(keybindings);
            }
            else if (type is ListType.Equipped)
            {
                CreateEquipped(keybindings);
            }
            else if (type is ListType.Areas)
            {
                CreateAreas(keybindings);
            }
            else if (type is ListType.Locations)
            {
                CreateLocations(keybindings);
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
            foreach (var item in keybindings)
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
                if (slotItem is not MiscItem)
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

        public void CreateAreas(IIndexedKeybinding[] keybindings)
        {
            int index = 0;
            foreach (var item in keybindings)
            {
                var area = AreaManager.GetAreaByObjectId<IArea>(item.Object.ObjectId);

                var areaName = new ColoredString(area.Name);

                var printableArea = new PrintContainerBase()
                {
                    Name = areaName,
                    Type = area.MinLevel == 0 && area.MaxLevel == 0 ? "\0" : $"<{area.MinLevel} - {area.MaxLevel}>",
                    Data = "\0",
                    Id = "\0",
                    ButtonIndex = new ButtonIndex(keybindings[index].Keybinding, Color.Green, Color.White, 0, 0, true)
                };

                _printable.Add(printableArea);
                index++;
            }
        }

        public void CreateLocations(IIndexedKeybinding[] keybindings)
        {
            int index = 0;
            foreach (var item in keybindings)
            {
                var location = LocationManager.GetLocationByObjectId<ILocation>(item.Object.ObjectId);

                ColoredString locationName = LocationManager.GetLocationName<ILocation>(location.ObjectId);

                if (location.ObjectId == Game.GameSession.Player.CurrentLocation.ObjectId)
                {
                    locationName.SetBackground(new Color(18, 77, 7));
                }

                var printableLocation = new PrintContainerBase()
                {
                    Name = locationName,
                    Type = location.MinLevel == 0 && location.MaxLevel == 0 ? "\0" : $"<{location.MinLevel} - {location.MaxLevel}>",
                    Data = "\0",
                    Id = "\0",
                    ButtonIndex = new ButtonIndex(keybindings[index].Keybinding, Constants.Theme.ButtonKeyColor, Constants.Theme.ForegroundColor, 0, 0, true)
                };

                _printable.Add(printableLocation);
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
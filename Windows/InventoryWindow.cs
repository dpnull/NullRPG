using System;
using System.Collections.Generic;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using System.Linq;
using NullRPG.ItemTypes;
using NullRPG.Input;
using NullRPG.GameObjects;
using System.ComponentModel;
using System.Reflection;

namespace NullRPG.Windows
{
    class InventoryWindow : Console, IUserInterface
    {
        private IndexedKeybindings IndexedKeybindings;
        public Console Console => this;
        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawInventory();

            DrawEquipButton();

            base.Draw(timeElapsed);
        }

        private void DrawEquipButton()
        {
            if (ItemManager.GetItem<IItem>(UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId) is WeaponItem)
            {
                var btn = new Input.ButtonString(new ColoredString("Equip"), Keybindings.GetKeybinding(Keybindings.Type.Equip), Constants.Theme.ButtonKeyColor, DefaultForeground,
                    Constants.Windows.PreviewX, Constants.Windows.PreviewY + Constants.Windows.ItemPreviewHeight - 1);

                btn.Draw(this);
            }
        }

        public override void OnFocusLost()
        {
            UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId = -1;
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            foreach (var key in IndexedKeybindings.GetIndexedKeybindings())
            {
                if (info.IsKeyPressed(key.Keybinding))
                {
                    
                    var itemPreviewWindow = UserInterfaceManager.Get<ItemPreviewWindow>();
                    itemPreviewWindow.
                        SetObjectForPreview(InventoryManager.GetSlot<ISlot>(Game.GameSession.Player.Inventory, IndexedKeybindings.GetIndexable(key.Index).ObjectId).Item.FirstOrDefault().ObjectId);
                    itemPreviewWindow.IsVisible = true;
                    return true;
                }

            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E)) // REWORK
            {
                Equip();
            }

            return false;
        }

        public void Equip()
        {
            var objectId = UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId;

            InventoryManager.EquipWeapon<IEntityInventory>(objectId);
        }

        private void DrawInventory()
        {
            this.DrawHeader(0, $"{Game.GameSession.Player.Name}'s Inventory", "+", DefaultForeground);

            var inventory = InventoryManager.GetSlots<PlayerInventory>();
            List<IIndexable> bindable = new List<IIndexable>(); // to be used for instantiating indexes and objectid reference


            foreach(var slot in inventory)
            {
                if (!slot.Item.Any())
                    continue;
                else
                {
                    if (slot.Item != null)
                    {
                        if (slot.Item.Any<IItem>(i => i.IsUnique))
                        {
                            bindable.Add((IIndexable)slot);
                        }
                        else
                        {
                            bindable.Add((IIndexable)slot);
                        }
                    }
                }
            }

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());
            PrintContainer printable = new PrintContainer(IndexedKeybindings.GetIndexedKeybindings());

            printable.Print(this);
        }

        public class PrintContainer
        {
            public int YOffset { get; private set; } = 0;
            public int XOffset { get; private set; } = 0;
            public int IndexOffset { get; private set; } = 0;
            public int NameOffset { get; private set; } = 4;
            public int TypeOffset { get; private set; } = 20;

            private readonly List<PrintContainer> _printable;
            public ColoredString Name { get; set; }
            public string Type { get; set; }
            public string Data { get; set; }
            public string Id { get; set; }
            public ButtonIndex ButtonIndex { get; set; }

            public PrintContainer(IIndexedKeybinding[] keybindings)
            {
                _printable = new List<PrintContainer>();
                Add(keybindings);
            }
            public PrintContainer()
            {
            }

            public void SetPrintingOffsets(int xOffset, int yOffset, int typeOffset)
            {
                YOffset = yOffset;
                IndexOffset = xOffset;
                NameOffset = xOffset + 4;
                TypeOffset = xOffset + typeOffset;
            }

            public void Add(IIndexedKeybinding[] keybindings)
            {
                int index = 0; // for keybinding index
                foreach(var item in keybindings)
                {
                    var slotItem = InventoryManager.GetSlot<ISlot>(Game.GameSession.Player.Inventory, item.Object.ObjectId).Item.FirstOrDefault();
                    ColoredString itemName = ItemManager.GetItemName<IItem>(slotItem.ObjectId);
                    
                    if(slotItem is MiscItem)
                    {
                        itemName += $" x{InventoryManager.GetSlot<ISlot>(Game.GameSession.Player.Inventory, item.Object.ObjectId).Item.Count}";
                    }

                    // temp
                    if(slotItem.ObjectId == Game.GameSession.Player.Inventory.CurrentWeapon.ObjectId)
                    {
                        //itemName.SetBackground(new Color(18,77,7));
                    }

                    // retrieves the description attribute from the class
                    string itemType = slotItem?.GetType().GetCustomAttribute<DescriptionAttribute>(false).Description;
                    string itemId = $"slotId_{InventoryManager.GetSlot<ISlot>(Game.GameSession.Player.Inventory, item.Object.ObjectId).ObjectId}, itemId_{slotItem.ObjectId}";

                    var printableItem = new PrintContainer()
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
                foreach(var str in _printable)
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
}
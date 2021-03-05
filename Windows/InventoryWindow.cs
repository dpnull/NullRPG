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
                var btn = new Input.ButtonString("Equip", Keybindings.GetKeybinding(Keybindings.Type.Equip), Constants.Theme.ButtonKeyColor, DefaultForeground,
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
                        SetObjectForPreview(InventoryManager.GetSlot<ISlot>(IndexedKeybindings.GetIndexable(key.Index).ObjectId).Item.FirstOrDefault().ObjectId);
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

            Game.GameSession.Player.EquipWeapon(objectId);
        }

        private void DrawInventory()
        {
            this.DrawHeader(0, $"{Game.GameSession.Player.Name}'s Inventory", "+", DefaultForeground);

            var inventory = InventoryManager.GetSlots<ISlot>();
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
            private const int INDEX_OFFSET = 0;
            private const int NAME_OFFSET = 4;
            private const int TYPE_OFFSET = 24;
            private const int DATA_OFFSET = 34;
            private const int ID_OFFSET = 54;

            private List<PrintContainer> _printable;
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

            public void Add(IIndexedKeybinding[] keybindings)
            {
                int index = 0; // for keybinding index
                foreach(var item in keybindings)
                {
                    var slotItem = InventoryManager.GetSlot<ISlot>(item.Object.ObjectId).Item.FirstOrDefault();
                    ColoredString itemName = ItemManager.GetItemName<IItem>(slotItem.ObjectId);
                    // temp
                    if(slotItem.ObjectId == Game.GameSession.Player.CurrentWeapon.ObjectId)
                    {
                        //itemName.SetBackground(new Color(18,77,7));
                    }

                    string itemType = slotItem is WeaponItem ? "[Weapon]" : slotItem is MiscItem ? "[Misc]" : "UNKNOWN TYPE";
                    string itemData = slotItem is WeaponItem ? $"Atk: {slotItem.MinDmg} - {slotItem.MaxDmg}" :
                                      slotItem is MiscItem ? $"Count: {InventoryManager.GetSlot<ISlot>(item.Object.ObjectId).Item.Count}" : "UNKNOWN ITEM DATA";
                    string itemId = $"slotId_{InventoryManager.GetSlot<ISlot>(item.Object.ObjectId).ObjectId}, itemId_{slotItem.ObjectId}";

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
                int _y = 3;
                foreach(var str in _printable)
                {
                    str.ButtonIndex.Draw(INDEX_OFFSET, _y, console);
                    console.Print(NAME_OFFSET, _y, str.Name);
                    console.Print(TYPE_OFFSET, _y, str.Type);
                    console.Print(DATA_OFFSET, _y, str.Data);
                    console.Print(ID_OFFSET, _y, str.Id);
                    _y++;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using NullRPG.GameObjects;
using SadConsole.Input;
using System.Linq;
using NullRPG.ItemTypes;

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
            DrawInventory();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            return base.ProcessKeyboard(info);
        }

        /*
        private void DrawPrintable()
        {
            Printable = InventoryManager.GetSlots<ISlot>(); // temp

            var empty = new List<String>();
            var printable = new List<String>();
            var bindable = new List<ISlot>();

            int y = 0;
            foreach (var item in Printable)
            {
                if (!item.Item.Any())
                {
                    string emptyStr = "[EMPTY]";
                    empty.Add(emptyStr);
                    continue;
                }
                else
                {
                    if (item.Item != null)
                    {
                        if (item.Item.Any<IItem>(i => i.ObjectId == Game.GameSession.Player.CurrentWeapon.ObjectId))
                        {
                            printable.Add($"id: {item.Item.First().ObjectId}    [{item.Item.First().Name}]     - EQUIPPED -");
                            bindable.Add(item);
                        }
                        else if (item.Item.Any<IItem>(i => i.IsUnique))
                        {
                            printable.Add($"id: {item.Item.First().ObjectId}    [{item.Item.First().Name}]");
                            bindable.Add(item);
                        }
                        else if (item.Item.Any<IItem>(i => !i.IsUnique))
                        {
                            printable.Add($"{item.Item.First().Name}   Quantity: {item.Item.Count}");
                            bindable.Add(item);
                        }
                    }
                }
            }

            foreach (var str in printable)
            {
                Print(0, y, str); y++;
            }

            foreach (var str in empty)
            {
                Print(0, y, str); y++;
            }
        }
        */

        private void DrawInventory()
        {
            var inventory = InventoryManager.GetSlots<ISlot>();

            PrintContainer container = new PrintContainer();

            List<IIndexable> bindable = new List<IIndexable>();


            foreach(var slot in inventory)
            {
                if (!slot.Item.Any())
                {
                    //string emptyStr = "[EMPTY]";
                    //container.Add(emptyStr, "\0", "\0");
                    continue;
                }
                else
                {
                    if(slot.Item != null)
                    {
                        if (slot.Item.Any<IItem>(i => i.IsUnique))
                        {
                            container.Add(slot.Item.FirstOrDefault().Name,
                                $"{slot.Item.FirstOrDefault().MinDmg} - {slot.Item.FirstOrDefault().MaxDmg}",
                                $"item_id{slot.Item.FirstOrDefault().ObjectId} | slot_id{slot.ObjectId}");
                            bindable.Add((IIndexable)slot);
                        } else
                        {
                            container.Add(slot.Item.FirstOrDefault().Name,
                                $"x{slot.Item.Count}",
                                $"item_id{slot.Item.FirstOrDefault().ObjectId} | slot_id{slot.ObjectId}");
                            bindable.Add((IIndexable)slot);
                        }
                    }
                }
            }

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());


            container.Print(this, IndexedKeybindings);
        }

        private class PrintContainer
        {
            private const int INDEX_OFFSET = 0;
            private const int NAME_OFFSET = 4;
            private const int PARAS_OFFSET = 20;
            private const int ID_OFFSET = 35;

            private int _startingX;
            private int _startingY;

            private List<PrintContainer> _printable;
            public int IndexX { get; set; }
            public string Name { get; set; }
            public int NameX { get; set; }
            public string Paras { get; set; }
            public int ParasX { get; set; }
            public string Id { get; set; }
            public int IdX { get; set; }

            public void SetParameters(int startingX, int startingY)
            {
                _startingX = startingX;
                _startingY = startingY;
            }

            public PrintContainer(IndexedKeybindings reference)
            {
                _printable = new List<PrintContainer>();
            }

            public PrintContainer()
            {
                _printable = new List<PrintContainer>();
            }

            public void Add(string name, string paras, string id)
            {
                var temp = new PrintContainer()
                {
                    IndexX = _startingX + INDEX_OFFSET,
                    Name = name,
                    NameX = _startingX + NAME_OFFSET,
                    Paras = paras,
                    ParasX = NameX + PARAS_OFFSET,
                    Id = id,
                    IdX = ParasX + ID_OFFSET
                };

                _printable.Add(temp);
            }

            public void Print(SadConsole.Console console, IndexedKeybindings bindings)
            {
                int _y = _startingY;
                int index = 0;
                foreach(var str in _printable)
                {
                    string weaponName = InventoryManager.GetSlot<ISlot>(bindings.GetIndexable(index).ObjectId).Item.FirstOrDefault().Name;
                    console.Print(0, _y, weaponName);
                    _y++;
                    index++;
                }
            }

            /*
            public void Print(SadConsole.Console console, IndexedKeybindings keybinding)
            {
                int yCoord = _startingY;
                int index = 0;
                foreach (var str in _printable)
                {               
                    var btn = new Button("\0", keybinding.GetIndexedKeybinding(index), Color.Green, console.DefaultForeground, IndexX, yCoord);
                    btn.DrawNumericOnly(true);
                    
                    index++;

                    if(str.Name == "[EMPTY]") { btn.KeyColor = Color.Gray; } // very lazy
                    btn.Draw(console);
                    console.Print(str.NameX, yCoord, str.Name);
                    console.Print(str.ParasX, yCoord, keybinding.GetIndexedItem(index);
                    console.Print(str.IdX, yCoord, str.Id);
                    yCoord++;
                }

            }
            */

            private String GetItemTypePara(IItem item)
            {
                // TODO: IMPLEMENT WEAPON TYPES AS PARAMETER FOR ITEM OBJECTS
                return item is WeaponItem ? "Weapon" : item is MiscItem ? "Miscellaneous" : "UNKNOWN TYPE";
            }
        }
    }
}

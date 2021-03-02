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
            var emptySlots = new List<String>();
            var printable = new List<String>();
            var bindable = new List<ISlot>();

            int _x = 1;
            int _y = 3;

            foreach(var slot in inventory)
            {
                if (!slot.Item.Any())
                {
                    string emptyStr = "[EMPTY]";
                    emptySlots.Add(emptyStr);
                    continue;
                }
                else
                {
                    if(slot.Item != null)
                    {
                       /*if(slot.Item.Any<IItem>(i => i.ObjectId == Game.GameSession.Player.CurrentWeapon.ObjectId))
                        {
                            string bindableStr = $"{slot}"
                        }*/
                        if (slot.Item.Any<IItem>(i => i.IsUnique))
                        {
                            string printableStr = $"[id_{slot.Item.First().ObjectId}]  {slot.Item.First().Name}     {slot.Item.First().MinDmg} - {slot.Item.First().MaxDmg}";

                            printable.Add(printableStr);
                            bindable.Add(slot);
                        } else
                        {
                            string printableStr = $"[id_{slot.Item.First().ObjectId}]  {slot.Item.First().Name}   Count: {slot.Item.Count}";

                            printable.Add(printableStr);
                            bindable.Add(slot);
                        }
                    }
                }
            }

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());

            if (emptySlots.Count > 0)
            {
                foreach(var str in emptySlots)
                {               
                    Print(_x, _y, str); _y++;
                }
            }

            if(bindable.Count > 0)
            {
                int index = 0;
                foreach (var str in printable)
                {
                    var btn = new Button(str, IndexedKeybindings.GetIndexedKeybinding(index), Color.Green, DefaultForeground, 0, index);
                    btn.DrawNumericOnly(true);
                    btn.Draw(this);
                    index++;
                }
            }

        }
    }
}

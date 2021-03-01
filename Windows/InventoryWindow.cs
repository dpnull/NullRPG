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

        private void DrawInventory()
        {
            var inventory = InventoryManager.GetSlots<ISlot>();
            var emptySlots = new List<String>();
            var bindable = new List<String>();

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

                            bindable.Add(printableStr);
                        } else
                        {
                            string printableStr = $"[id_{slot.Item.First().ObjectId}]  {slot.Item.First().Name}   Count: {slot.Item.Count}";

                            bindable.Add(printableStr);
                        }
                    }
                }
            }

            if (emptySlots.Count > 0)
            {
                foreach(var str in emptySlots)
                {
                    Print(_x, _y, str); _y++;
                }
            }

            if(bindable.Count > 0)
            {
                foreach (var str in bindable)
                {
                    Print(_x, _y, str); _y++;
                }
            }

        }
    }
}

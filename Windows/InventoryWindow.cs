﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    internal class InventoryWindow : Console, IUserInterface
    {
        private const int TYPE_OFFSET = 25;
        private const int X_OFFSET = 0;
        private const int Y_OFFSET = 3;
        private IndexedKeybindings IndexedKeybindings;
        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }

        public Console Console => this;
        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawInventory();

            DrawEquipButton();

            base.Draw(timeElapsed);
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
                    return true;
                }
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.P))
            {
                TestChopping();
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

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.U))
            {
                Enchant.EnchantSteel(Game.GameSession.Player.Inventory.CurrentWeapon);
            }

            return false;
        }

        private void TestChopping()
        {
            var player = Game.GameSession.Player;
            var currentLocation = LocationManager.GetLocationByObjectId<ILocation>(player.CurrentLocation.ObjectId);

            if(currentLocation.Name == "Forest")
            {
                var itemToAdd = currentLocation.WorldObjects.FirstOrDefault().Items.FirstOrDefault();
                InventoryManager.AddToInventory<PlayerInventory>(itemToAdd);
            }
        }

        private static void Equip()
        {
            var objectId = UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId;
            InventoryManager.EquipItem<PlayerInventory>(objectId);
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

        private void DrawInventory()
        {
            this.DrawHeader(0, $"  {Game.GameSession.Player.Name}'s inventory overview ", Constants.Theme.HeaderForegroundColor, Constants.Theme.HeaderBackgroundColor);

            var inventory = InventoryManager.GetSlots<PlayerInventory>();
            List<IIndexable> bindable = new List<IIndexable>(); // to be used for instantiating indexes and objectid reference

            foreach (var slot in inventory)
            {
                if (!slot.Item.Any())
                    continue;
                else
                    if (slot.Item != null)
                {
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
            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings.GetIndexedKeybindings(), PrintContainerBase.ListType.Inventory);
            printable.SetPrintingOffsets(X_OFFSET, Y_OFFSET, TYPE_OFFSET);

            printable.Print(this);
        }
    }
}
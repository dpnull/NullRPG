using Microsoft.Xna.Framework;
using NullRPG.Draw;
using NullRPG.Extensions;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using static NullRPG.Input.Keybinding;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class InventoryWindow : Console, IUserInterface
    {
        public Console Console => this;
        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }

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

        public override void OnFocusLost()
        {
            UserInterfaceManager.Get<ItemPreviewWindow>().SetObjectForPreview(-1);

            base.OnFocusLost();
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            foreach (var keybinding in IndexedKeybindings)
            {
                if (info.IsKeyPressed(keybinding.Key))
                {
                    var itemPreviewWindow = UserInterfaceManager.Get<ItemPreviewWindow>();
                    itemPreviewWindow.
                        SetObjectForPreview(InventoryManager.GetInventorySlot(Game.GameSession.Player, keybinding.ObjectId).Item.FirstOrDefault().ObjectId);
                    return true;
                }
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
                return true;
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
            {
                    EquipItem();
                return true;
            }

            return false;
        }

        private void EquipItem()
        {
            var objectId = UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId;
            EntityManager.EquipItem<IEntity>(EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId), objectId);
            
        }

        private void DrawEquipButton()
        {
            if (UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId != -1)
            {
                var item = ItemManager.Get<IItem>(UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId);
                if (item.HasComponent<ItemComponents.EquippableComponent>())
                {
                    var equipBtn = new Input.ButtonString(new ColoredString("Equip"), Microsoft.Xna.Framework.Input.Keys.E,
                        Constants.Theme.ButtonKeyColor, DefaultForeground,
                        Constants.Windows.PreviewX, Constants.Windows.PreviewY + Constants.Windows.ItemPreviewHeight - 1);

                    foreach (var equipped in EntityManager.GetEquippedItems(Game.GameSession.Player))
                    {
                        if (equipped.ObjectId == item.ObjectId)
                        {
                            equipBtn.KeyColor = Color.DarkOliveGreen;
                            equipBtn.NameColor = Color.Gray; // INVESTIAGE
                        }
                    }
                    equipBtn.Draw(this);
                }
            }
        }

        private void DrawInventory()
        {
            this.DrawHeader(0, "Character inventory", Constants.Theme.HeaderForegroundColor, Constants.Theme.HeaderBackgroundColor);

            var inventory = InventoryManager.GetInventorySlots<IComponentSystemEntity>(Game.GameSession.Player);
            List<IIndexable> bindable = new();

            foreach (var slot in inventory)
            {
                if (!slot.Item.Any())
                    continue;
                else
                    if (slot.Item != null)
                {
                    bindable.Add(slot);
                }
            }

            IndexedKeybindings = IndexedKeybindingsManager.CreateIndexedKeybindings<IIndexedKeybinding>(bindable);
            PrintContainerInventory printable = new PrintContainerInventory(Game.GameSession.Player.GetComponent<EntityComponents.Inventory>().EntityInventory, IndexedKeybindings);

            printable.Draw(this, 2);
        }
    }
}
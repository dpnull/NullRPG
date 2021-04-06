using Microsoft.Xna.Framework;
using NullRPG.Draw;
using NullRPG.Extensions;
using NullRPG.GameObjects.Components.Item;
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
                        SetObjectForPreview(InventoryManager.GetInventorySlot<ISlot>(Game.GameSession.Player, keybinding.ObjectId).Item.FirstOrDefault().ObjectId);
                    return true;
                }
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
                return true;
            }

            return false;
        }

        /*
        private void DrawCurrentWeapon()
        {
            var inven

            var weapon = Game.GameSession.PlayerInventory.WeaponSlot;

            var minDmg = weapon.GetComponent<WeaponComponent>().MinDamage;
            var maxDmg = weapon.GetComponent<WeaponComponent>().MaxDamage;

            Print(0, 4, weapon.Name);
            Print(0, 5, $"{minDmg} - {maxDmg}");
            Print(0, 7, weapon.ItemType.ToString());

            var armor = Game.GameSession.PlayerInventory.HeadSlot;

            var defense = armor.GetComponent<ArmorComponent>().Defense;

            Print(0, 9, defense.ToString());
        }
        */

        private void DrawEquipButton()
        {
            if (UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId != -1)
            {
                var item = ItemManager.GetItem<IItem>(UserInterfaceManager.Get<ItemPreviewWindow>().ObjectId);
                if (ComponentManager.ContainsComponent<ItemPropertyComponent>(item.ObjectId))
                {
                    if (ComponentManager.ContainsItemProperty(item, Enums.ItemProperties.Equippable))
                    {
                        var equipBtn = new Input.ButtonString(new ColoredString("Equip"), Microsoft.Xna.Framework.Input.Keys.E,
                            Constants.Theme.ButtonKeyColor, DefaultForeground,
                            Constants.Windows.PreviewX, Constants.Windows.PreviewY + Constants.Windows.ItemPreviewHeight - 1);

                        equipBtn.Draw(this);
                    }
                }
            }
        }

        private void DrawInventory()
        {
            this.DrawHeader(1, "Character inventory", Constants.Theme.HeaderForegroundColor, Constants.Theme.HeaderBackgroundColor);

            var inventory = InventoryManager.GetSlots(Game.GameSession.Player);
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
            PrintContainerInventory printable = new PrintContainerInventory(InventoryManager.GetEntityInventory(Game.GameSession.Player), IndexedKeybindings);

            printable.Draw(this, 4);
        }
    }
}
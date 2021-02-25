using System;
using System.Collections.Generic;
using System.Text;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.GameObjects;
using Microsoft.Xna.Framework;
using SadConsole;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;

namespace NullRPG.Windows
{
    public class InventoryWindow : Console, IUserInterface
    {
        private IndexedKeybindings IndexedKeybindings;

        public Console Console { get; set; }

        private InventorySlot[] Printable { get; set; }

        private string CurrentSort { get; set; }

        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            CurrentSort = "All items";

            Printable = ShowAll(Game.GameSession.Player);

            // Assign the new index keys
            IndexedKeybindings = new IndexedKeybindings(Printable);

            Global.CurrentScreen.Children.Add(this);
        }


        public override void Update(TimeSpan timeElapsed)
        {
            Draw();
            base.Update(timeElapsed);
        }

        private void Draw()
        {
            Clear();
            DrawInventory();
            DrawFilters();
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                Game.WindowManager.CloseCurrentWindow(this);
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = null;
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.All)))
            {
                Printable = ShowAll(Game.GameSession.Player);
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Miscellaneous)))
            {
                Printable = ShowMisc(Game.GameSession.Player);
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Equipment)))
            {
                Printable = ShowEquipment(Game.GameSession.Player);
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Equip)))
            {
                Game.CommandManager.EquipItem(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item);
                return true;
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(1)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(1);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(2)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(2);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(3)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(3);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(4)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(4);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(5)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(5);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(6)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(6);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(7)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(7);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(8)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(8);
            }

            if (info.IsKeyPressed(IndexedKeybindings.GetInventoryKeybinding(9)))
            {
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = IndexedKeybindings.GetIndexedItem(9);
            }

            return false;
        }



        private void DrawInventory()
        {
            this.PrintInsideSeparators(1, CurrentSort, true);
            if (Printable != null)
            {
                IndexedKeybindings = new IndexedKeybindings(Printable);
                // Reassign the new index keys

                for (int i = 0; i < Printable.Length; i++)
                {
                    string name = $"{Printable[i].Item.Name}";
                    if (Printable[i].Item is MiscItem)
                    {
                        name = $"{Printable[i].Item.Name}  x{Printable[i].Quantity}";
                    }
                                        


                    this.PrintButton(1, i + 3, name, IndexedKeybindings._indexedInventoryKeybindings[i].Index.ToString(), Color.Green, false);
                }
                /*
                int y = 1; int x = 1;
                foreach (var item in Printable)
                {
                    string name = $"- {item.Name} -";
                    string value = $"Val: {item.Gold}";
                    Print(x, y, name);
                    Print(x + 25, y, value);
                    y++;
                }
                */
                PrintItemOptions();
            }
        }

        private void PrintItemOptions()
        {
            if (UserInterfaceManager.Get<ViewItemWindow>().DrawableItem != null)
            {
                // Draw only if item is not misc
                if (!(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item is MiscItem))
                {
                    this.PrintButton(UserInterfaceManager.Get<ViewItemWindow>().Position.X, Constants.Windows.ViewItemHeight + 2 + Constants.Windows.KeybindingsHeight,
                        Keybindings.GetKeybindingName(Keybindings.Type.Equip),
                        Keybindings.GetKeybindingChar(Keybindings.Type.Equip), Color.Green, false);
                }
            }
        }

        private InventorySlot[] ShowAll(Player player)
        {
            CurrentSort = "All Items";
            return player.Inventory.GetInventory();
        }

        private InventorySlot[] ShowMisc(Player player)
        {
            CurrentSort = "Miscellaneous Items";
            return player.Inventory.GetMisc();
        }

        private InventorySlot[] ShowEquipment(Player player)
        {
            CurrentSort = "Equipment Items";
            return player.Inventory.GetEquipment();
        }

        private void DrawFilters()
        {
            int x = 1;
            int y = Constants.Windows.InventoryHeight - Constants.Windows.KeybindingsHeight - 4;
            var all = Keybindings.GetKeybindingObject(Keybindings.Type.All).TypeName.ToString();
            var eq = Keybindings.GetKeybindingObject(Keybindings.Type.Equipment).TypeName.ToString();
            var misc = Keybindings.GetKeybindingObject(Keybindings.Type.Miscellaneous).TypeName.ToString();
            this.PrintButton(x, y, all, Keybindings.GetKeybindingChar(Keybindings.Type.All), Color.Green, false);
            this.PrintButton(x, y - 1, eq, Keybindings.GetKeybindingChar(Keybindings.Type.Equipment), Color.Green, false);
            this.PrintButton(x, y - 2, misc, Keybindings.GetKeybindingChar(Keybindings.Type.Miscellaneous), Color.Green, false);
            //this.PrintButton(x + eq.Length + all.Length + spacing, 1, misc, Keybindings.GetKeybindingChar(Keybindings.Type.Miscellaneous), Color.Green, false);
        }
    }
}

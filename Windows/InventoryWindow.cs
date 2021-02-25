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
using System.Linq;

namespace NullRPG.Windows
{
    public class InventoryWindow : Console, IUserInterface
    {
        private IndexedKeybindings IndexedKeybindings;

        public Console Console { get; set; }

        private Slot[] Printable { get; set; }

        private enum SortType
        {
            All,
            Misc,
            Equipment
        }

        private SortType CurrentSort { get; set; }

        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            CurrentSort = SortType.All;

            Printable = ShowItems(Game.GameSession.Player);

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
            bool updatePrintable = false;

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                Game.WindowManager.CloseCurrentWindow(this);
                UserInterfaceManager.Get<ViewItemWindow>().DrawableItem = null;
                return true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.All)))
            {
                CurrentSort = SortType.All;
                updatePrintable = true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Miscellaneous)))
            {
                CurrentSort = SortType.Misc;
                updatePrintable = true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Equipment)))
            {
                CurrentSort = SortType.Equipment;
                updatePrintable = true;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Equip)))
            {
                Game.CommandManager.EquipItem(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item);
                updatePrintable = true;
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

            if (updatePrintable)
            {
                Printable = ShowItems(Game.GameSession.Player);
            }

            return false;
        }

        private void DrawInventory()
        {
            // temporary hack for printing currently equipped text next to currently worn item
            bool equippedDrawn = false;

            string sortName;
            if (CurrentSort is SortType.Equipment) { sortName = "Equipment items"; }
            else if (CurrentSort is SortType.Misc) { sortName = "Miscellaneous items"; }
            else { sortName = "All items"; }
            this.PrintInsideSeparators(1, sortName, true);

            if (Printable != null)
            {
                // Reassign the new index keys
                IndexedKeybindings = new IndexedKeybindings(Printable);               

                for (int i = 0; i < Printable.Length; i++)
                {

                    /* Equipped item highlight currently unused
                    string name;
                    var comparator = Printable.FirstOrDefault(c => c.Item.ID == Printable[i].Item.ID);
                    if(Game.GameSession.Player.Inventory.GetCurrentWeapon().Item.ID == comparator.Item.ID && !equippedDrawn)
                    {
                        name = $"{Printable[i].Item.Name} [[ EQUIPPED ]]";
                        equippedDrawn = true;
                    }
                    */
                    // Add quantity for misc items
                    string name = $"{Printable[i].Item.Name}";
                    if (Printable[i].Item is MiscItem)
                    {
                        name = $"{Printable[i].Item.Name}  x{Printable[i].Quantity}";
                    }
                    this.PrintButton(1, i + 3, name, IndexedKeybindings._indexedInventoryKeybindings[i].Index.ToString(), Color.Green, false);
                }
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

        private Slot[] ShowItems(Player player)
        {
            if(CurrentSort is SortType.All) { return player.Inventory.GetInventory(); }
            else if(CurrentSort is SortType.Misc) { return player.Inventory.GetMisc(); }
            else if (CurrentSort is SortType.Equipment) { return player.Inventory.GetEquipment(); }
            else
            {
                return null;
            }
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

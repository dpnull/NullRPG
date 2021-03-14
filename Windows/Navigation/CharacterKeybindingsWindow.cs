using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Navigation
{
    public class CharacterKeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;

        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }

        public CharacterKeybindingsWindow(int width, int height) : base(width, height)
        {
            this.Parent = UserInterfaceManager.Get<KeybindingsWindow>();
        }

        public void Draw()
        {
            Clear();

            DrawKeybindings();
        }

        private void DrawKeybindings()
        {
            this.DrawRectangle(0, 0, Width, Height - 1, "+", "-", "|");

            var equipped = InventoryManager.GetEquippedItems<PlayerInventory>();
            List<IIndexable> bindable = new List<IIndexable>();

            foreach (var item in equipped)
            {
                if (item is null)
                    continue;
                else
                {
                    bindable.Add((IIndexable)item);
                }
            }

            IndexedKeybindings = IndexedKeybindingsManager.CreateIndexedKeybindings<IIndexedKeybinding>(bindable);

            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings, PrintContainerBase.ListType.Equipped);
            printable.RawSetPrintingOffsets(2, 1, 0, 14, 4);

            printable.Print(this);
        }
    }
}
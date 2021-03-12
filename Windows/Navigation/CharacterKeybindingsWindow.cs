using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using System.Linq;
using SadConsole.Input;
using NullRPG.Input;
using NullRPG.GameObjects.Worlds;
using NullRPG.GameObjects;

namespace NullRPG.Windows.Navigation
{
    public class CharacterKeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;

        public IndexedKeybindings IndexedKeybindings { get; private set; }

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

            IndexedKeybindings = new IndexedKeybindings(bindable.ToArray());

            PrintContainerBase printable = new PrintContainerBase(IndexedKeybindings.GetIndexedKeybindings(), PrintContainerBase.ListType.Equipped);
            printable.RawSetPrintingOffsets(2, 1, 0, 14, 4);

            printable.Print(this);

            var cancelBtn = new ButtonString(new ColoredString(Keybindings.GetKeybindingName(Keybindings.Type.Cancel)),
                Keybindings.GetKeybinding(Keybindings.Type.Cancel), Constants.Theme.ButtonKeyColor, DefaultForeground, 2, Height - 2, false);
            cancelBtn.Draw(this);
        }
    }
}

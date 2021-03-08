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
using NullRPG.ItemTypes;
using NullRPG.Input;
using static NullRPG.Windows.InventoryWindow;

namespace NullRPG.Windows
{
    public class CharacterWindow : Console, IUserInterface
    {
        public Console Console => this;

        private const int EQUIPPABLE_X = 1;
        private const int EQUIPPABLE_Y = Constants.Windows.CharacterHeight - 5;

        private IndexedKeybindings IndexedKeybindings;
        public CharacterWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            DrawDetailedStats();

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawDetailedStats();

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
                        SetObjectForPreview(IndexedKeybindings.GetIndexable(key.Index).ObjectId);
                    return true;
                }
            }

            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
            {
                Game.GameSession.Player.Experience += 1;
            }

            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
            }

            return false;
        }

        private void DrawDetailedStats()
        {
            var player = EntityManager.Get<Player>(Game.GameSession.Player.ObjectId);
            DrawExperience(player, 0, 3, Width);
            DrawCharacter(player);
            DrawEquippable();
        }

        private void DrawExperience(Player player, int x, int y, int width)
        {      
            string bar = "[";

            double percent = (double)player.Experience / player.ExperienceNeeded;
            int complete = Convert.ToInt32(percent * width);
            //int incomplete = width - complete;

            for (int i = 0; i < complete; i++)
            {
                bar += "#";
            }

            for (int i = complete; i < width - 2; i++)
            {
                bar += ".";
            }

            bar += "]";

            Print(x, y, bar);
            string printableExperience = $"EXP: {player.Experience} / {player.ExperienceNeeded}";
            Print(this.GetWindowXCenter() - (printableExperience.Length / 2), y + 1, printableExperience);
        }

        private void DrawCharacter(Player player)
        {
            int _x = 1;
            int _y = 4;
            this.DrawHeader(0, $"{player.Name}'s character overview", "+", Color.Green); _y++;

            string level = $"Level: {player.Level}";
            string health = $"Health: {player.Health} / {player.MaxHealth}";
            string defense = $"Defense: {player.Defense}";
            string damage = $"Attack: {player.MinDmg} - {player.MaxDmg}";
            string gold = $"Gold: {player.Gold}";
            

            Print(_x, _y, level); _y++;
            Print(_x, _y, health); _y++;
            Print(_x, _y, defense); _y++;
            Print(_x, _y, damage); _y += 2;
            Print(_x, _y, gold); _y += 2;
        }

        private void DrawEquippable()
        {
            var equipped = InventoryManager.GetEquippedItems<PlayerInventory>();
            List<IIndexable> bindable = new List<IIndexable>();

            foreach(var item in equipped)
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
            printable.RawSetPrintingOffsets(EQUIPPABLE_X, EQUIPPABLE_Y, 0, 15, 4);

            printable.Print(this);
        }

    }
}

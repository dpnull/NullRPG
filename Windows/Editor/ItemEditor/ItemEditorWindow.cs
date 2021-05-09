using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Editor.ItemEditor
{
    public class ItemEditorWindow : Console, IUserInterface
    {
        private ButtonString newItemBtn;
        private ButtonString viewItemsBtn;

        public Console Console => this;

        private bool _drawExistingItems = false;

        public ItemEditorWindow(int width, int height) : base(width, height)
        {
            
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            this.DrawHeader(0, "Game items", Color.Aqua, DefaultBackground);

            DrawButtons();

            if (_drawExistingItems)
            {
                DrawExistingItems();
            }

            base.Draw(timeElapsed);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            newItemBtn = new ButtonString(new ColoredString("New item"), Microsoft.Xna.Framework.Input.Keys.V, Constants.Theme.ButtonKeyColor, DefaultForeground, 0, 4, false);
            viewItemsBtn = new ButtonString(new ColoredString("Views existing items"), Microsoft.Xna.Framework.Input.Keys.Q, Constants.Theme.ButtonKeyColor, DefaultForeground, 0, 5, false);
            if (_drawExistingItems)
            {
                viewItemsBtn.Name = new ColoredString("Close viewing existing items");
            }

            base.Update(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(viewItemsBtn.Key))
            {
                _drawExistingItems = _drawExistingItems is false ? true : false;
                return true;
            }
           
            if (info.IsKeyPressed(newItemBtn.Key))
            {
                OpenNewItemCreator();
                return true;
            }
            
            return false;
        }

        private void OpenNewItemCreator()
        {
            if (UserInterfaceManager.Get<NewItemWindow>() is null)
            {
                var itemEditorWindow = new NewItemWindow(Constants.GameWidth, Constants.GameHeight)
                {
                    IsVisible = false,
                    IsFocused = false
                };
                UserInterfaceManager.Add(itemEditorWindow);

                var window = UserInterfaceManager.Get<NewItemWindow>();
                window.IsVisible = true;
                window.IsFocused = true;
                Global.CurrentScreen = window;
            }
            else
            {
                this.FullTransition(UserInterfaceManager.Get<NewItemWindow>());
            }
            /*
            if (UserInterfaceManager.Get<NewItemWindow>() != null)
            {
                UserInterfaceManager.Remove(UserInterfaceManager.Get<NewItemWindow>());
            }
            if (UserInterfaceManager.Get<NewItemWindow>() is null)
            {
                var newItemWindow = new NewItemWindow(Constants.Editor.EDITOR_ITEM_W, Constants.Editor.EDITOR_ITEM_H);
                UserInterfaceManager.Add(newItemWindow);
            }
            this.FullTransition(UserInterfaceManager.Get<NewItemWindow>().Console);
            */
        }

        private void DrawButtons()
        {
            newItemBtn.Draw(this);
            viewItemsBtn.Draw(this);
        }

        private void DrawExistingItems()
        {
            var collection = ItemManager.GetAll<IItem>();

            int _y = 6;

            this.DrawSeparator(_y, "-", DefaultForeground); _y++;

            
            foreach(var item in collection)
            {
                Print(0, _y, $"[id:{item.ObjectId}] Name: {item.Name}");
                _y++;
            }

            this.DrawSeparator(_y, "-", DefaultForeground);
        }
    }
}

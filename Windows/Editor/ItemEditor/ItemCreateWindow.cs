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
    public class ItemCreateWindow : Console, IUserInterface
    {
        private ButtonString newItemBtn;
        private ButtonString viewItemsBtn;

        public Console Console => this;

        private bool _drawExistingItems = false;

        public ItemCreateWindow(int width, int height) : base(width, height)
        {
            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawButtons();

            if (_drawExistingItems)
            {
                DrawExistingItems();
            }

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(viewItemsBtn.Key))
            {
                _drawExistingItems = _drawExistingItems is false ? true : false;
                return true;
            }

            return false;
        }

        private void DrawButtons()
        {
            newItemBtn = new ButtonString(new ColoredString("New item"), Microsoft.Xna.Framework.Input.Keys.V, Constants.Theme.ButtonKeyColor, DefaultForeground, 0, 4, false);
            viewItemsBtn = new ButtonString(new ColoredString("Views existing items"), Microsoft.Xna.Framework.Input.Keys.Q, Constants.Theme.ButtonKeyColor, DefaultForeground, 0, 5, false);

            newItemBtn.Draw(this);
            viewItemsBtn.Draw(this);
        }

        private void DrawExistingItems()
        {
            var collection = ItemManager.GetAll<IItem>();

            int _y = 6;
            foreach(var item in collection)
            {
                Print(0, _y, $"[id:{item.ObjectId}] Name: {item.Name}");
                _y++;
            }
        }
    }
}

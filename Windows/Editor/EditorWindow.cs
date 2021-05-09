using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Editor.ItemEditor;
using SadConsole;
using SadConsole.Input;
using System;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows.Editor
{
    public class EditorWindow : Console, IUserInterface
    {
        public Console Console => this;

        private ButtonString itemEditorBtn;

        public EditorWindow(int width, int height) : base(width, height)
        {
            Global.CurrentScreen = this;
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawMenu();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.I))
            {
                OpenItemEditor();
                return true;
            }

            return false;
        }

        public override void Update(TimeSpan timeElapsed)
        {
            itemEditorBtn = new ButtonString(new ColoredString("Items"), Microsoft.Xna.Framework.Input.Keys.I, Constants.Theme.ButtonKeyColor, DefaultForeground, 0, 4, false);

            base.Update(timeElapsed);
        }

        private void OpenItemEditor()
        {
            if (UserInterfaceManager.Get<ItemEditorWindow>() is null)
            {
                var itemEditorWindow = new ItemEditorWindow(Constants.GameWidth, Constants.GameHeight)
                {
                    IsVisible = false,
                    IsFocused = false
                };
                UserInterfaceManager.Add(itemEditorWindow);

                var window = UserInterfaceManager.Get<ItemEditorWindow>();
                window.IsVisible = true;
                window.IsFocused = true;
                Global.CurrentScreen = window;
            }
            else
            {
                this.FullTransition(UserInterfaceManager.Get<ItemEditorWindow>());
            }
        }

        private void DrawMenu()
        {
            this.DrawHeader(1, "NULLRPG GAME EDITOR", DefaultForeground, DefaultBackground);

            itemEditorBtn.Draw(this);
        }
    }
}

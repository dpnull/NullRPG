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
    public class MainEditorWindow : Console, IUserInterface
    {
        public Console Console => this;

        public MainEditorWindow(int width, int height) : base(width, height)
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
                this.FullTransition(UserInterfaceManager.Get<ItemCreateWindow>());
                return true;
            }

            return false;
        }

        private void DrawMenu()
        {
            this.DrawHeader(1, "NULLRPG GAME EDITOR", DefaultForeground, DefaultBackground);

            var newItemBtn = new ButtonString(new ColoredString("Items"), Microsoft.Xna.Framework.Input.Keys.I, Constants.Theme.ButtonKeyColor, DefaultForeground, 0, 4, false);

            newItemBtn.Draw(this);
        }
    }
}

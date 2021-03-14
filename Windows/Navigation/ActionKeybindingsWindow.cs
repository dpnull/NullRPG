using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using Console = SadConsole.Console;
namespace NullRPG.Windows.Navigation
{
    class ActionKeybindingsWindow : BaseKeybindingsWindow, IUserInterface
    {
        public ActionKeybindingsWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.ActionKeybindingsX, Constants.Windows.ActionKeybindingsY);

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



            Print(2, 2, "TEST1111121");
        }
    }
}

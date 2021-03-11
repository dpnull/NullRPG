using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.Extensions;
namespace NullRPG.Windows
{
    public class MessageWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        public MessageWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.MessageX, Constants.Windows.MessageY);

            Global.CurrentScreen.Children.Add(this);
        }


        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();
            this.DrawSeparator(0, "-", DefaultForeground);
            MessageManager.Draw(this, 1, 1);

            base.Draw(timeElapsed);
        }
    }
}

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
            Position = new Point(0, Constants.GameHeight - Constants.Windows.KeybindingsHeight - Height);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            Clear();

            MessageQueue.Draw(this);

            base.Update(timeElapsed);
        }
    }
}

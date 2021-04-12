using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using SadConsole.Input;
using System;
using Console = SadConsole.Console;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Managers;

namespace NullRPG.Windows
{
    public class MessageWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public MessageWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.MessageX, Constants.Windows.MessageY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawMessageLog();

            base.Draw(timeElapsed);
        }

        private void DrawMessageLog()
        {
            this.DrawSeparator(0, "-", Color.LightGray);

            var messages = MessageManager.GetMessages();

            foreach (var message in messages)
            {
                Print(0, 1, message.MessageString);
            }
        }
    }
}

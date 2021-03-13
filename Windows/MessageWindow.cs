using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Interfaces;
using SadConsole;
using System;
using Console = SadConsole.Console;

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

        private static readonly int tickLimit = 200;
        private static int CurrentTick = 0;
        private static bool canDraw = false;

        public override void Draw(TimeSpan timeElapsed)
        {
            // temporary solution to clearing notification
            if (canDraw)
            {
                Clear();
                MessageManager.Draw(this, 1, 1);
                canDraw = false;
            }

            CurrentTick++;
            if (CurrentTick >= tickLimit)
            {
                Clear();
            }

            this.DrawSeparator(0, "-", DefaultForeground);

            base.Draw(timeElapsed);
        }

        public static void OnMessageAdded()
        {
            CurrentTick = 0;
            canDraw = true;
        }
    }
}
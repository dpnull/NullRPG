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

        static readonly int tickLimit = 200; 
        static int CurrentTick = 0;
        static bool canDraw = false;
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
            if(CurrentTick >= tickLimit)
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

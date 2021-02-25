using System;
using System.Collections.Generic;
using System.Text;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.GameObjects;
using Microsoft.Xna.Framework;
using SadConsole;
using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using System.Linq;

namespace NullRPG.Windows
{
    class LocActionsWindow : Console, IUserInterface
    {
        public Console Console { get; set; }

        public LocActionsWindow(int width, int height) : base(width, height)
        {


            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            base.Update(timeElapsed);
        }

        private void DisplayAvailableActionsAtLocation()
        {

        }
    }
}

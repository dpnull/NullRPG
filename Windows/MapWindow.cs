using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Actors;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Editor;
using SadConsole;
using SadConsole.Input;
using System;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class MapWindow : Console, IUserInterface
    {
        public Console Console { get; }



        public MapWindow(int width, int height) : base(width, height)
        {
            DefaultBackground = Color.Blue;

            Position = new Point(Constants.Windows.MapX, Constants.Windows.MapY);

            Global.CurrentScreen.Children.Add(this);
        }
    }
}

using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Navigation;
using SadConsole;
using SadConsole.Input;
using System;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class ChoppingWindow : Console, IUserInterface
    {
        public Console Console => this;
        public ChoppingWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.Actions.ChoppingX, Constants.Windows.Actions.ChoppingY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawChopping();

            base.Draw(timeElapsed);
        }

        private void DrawChopping()
        {
            var player = EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId);
            var location = LocationManager.GetLocationByObjectId<ILocation>(player.CurrentLocation.ObjectId);
            var treeObjects = WorldObjectManager.GetLocationWorldObjectsByObjectType<IWorldObject>(location, WorldObjectBase.Objects.Tree);

            int _x = 0;
            int _y = 0;
            Print(_x, _y, "This forest consists of trees of type:"); _y++;
            foreach(var tree in treeObjects)
            {
                Print(_x, _y, tree.Name); _y++;
            }
        }
    }
}

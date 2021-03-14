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
using System.Linq;

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
            Clear();

            DrawChopping();

            base.Draw(timeElapsed);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {


            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.H))
            {
                ChopWood();
                return true;
            }

            if (info.IsKeyPressed(KeybindingManager.GetKeybinding<IKeybinding>(Keybinding.Keybindings.Back)))
            {
                this.FullTransition(UserInterfaceManager.Get<GameWindow>());
            }

            return false;
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

            Print(_x, _y, $"Press H to chop wood.");
        }

        private static void ChopWood()
        {
            var player = Game.GameSession.Player;
            var currentLocation = LocationManager.GetLocationByObjectId<ILocation>(player.CurrentLocation.ObjectId);

            if (WorldObjectManager.ContainsWorldObject(currentLocation, WorldObjectBase.Objects.Tree))
            {
                var tree = WorldObjectManager.GetLocationWorldObjectsByObjectType<IWorldObject>(currentLocation, WorldObjectBase.Objects.Tree).FirstOrDefault();

                var reward = tree.Items.FirstOrDefault();

                InventoryManager.AddToInventory<PlayerInventory>(reward);
                MessageManager.AddItemObtained(reward.Name, 1);
            }
        }
    }
}

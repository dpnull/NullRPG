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

        private PlayerActor _playerActor;

        public MapWindow(int width, int height) : base(width, height)
        {
            _playerActor = (PlayerActor)ActorManager.Get<IActor>(Game.GameSession.PlayerActor.ObjectId);
            _playerActor.Actor.Position = new Point(0, 1);

            Position = new Point(Constants.Windows.MapX, Constants.Windows.MapY);

            this.Children.Add(_playerActor.Actor);


            Global.CurrentScreen.Children.Add(this);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                CommandManager.MoveUp(_playerActor.Actor);
                return true;
            }
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                CommandManager.MoveDown(_playerActor.Actor);
                return true;
            }
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                CommandManager.MoveLeft(_playerActor.Actor);
                return true;
            }
            if (info.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                CommandManager.MoveRight(_playerActor.Actor);
                return true;
            }
            return false;
        }


    }
}

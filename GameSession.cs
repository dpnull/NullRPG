using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.GameObjects;
using NullRPG.GameObjects.Worlds;
using NullRPG.Managers;

namespace NullRPG
{
    public class GameSession
    {
        public Player Player { get; set; }
        public World World { get; set; }
        public GameSession()
        {
            Player = EntityManager.Create<Player>();
            World = new Overworld();
        }
    }
}

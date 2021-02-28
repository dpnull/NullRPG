using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.GameObjects;
using NullRPG.Managers;

namespace NullRPG
{
    public class GameSession
    {
        public static Player Player { get; set; }
        public GameSession()
        {
            Player = EntityManager.Create<Player>();
        }
    }
}

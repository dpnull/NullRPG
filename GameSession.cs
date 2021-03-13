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
            World = new Overworld();
            Player = EntityManager.Create<Player>();
        }
    }
}
using NullRPG.GameObjects.Entity;
using NullRPG.Managers;

namespace NullRPG
{
    public class GameSession
    {
        public Player Player { get; private set; }

        public GameSession()
        {
            WorldManager.AddWorld(new GameObjects.Worlds.Overworld());

            IndexedKeybindingsManager.Initialize();
            Player = EntityManager.Create<Player>();
        }
    }
}
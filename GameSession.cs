using NullRPG.GameObjects.Entity;
using NullRPG.Managers;

namespace NullRPG
{
    public class GameSession
    {
        public Player Player { get; private set; }

        public GameSession()
        {
            IndexedKeybindingsManager.Initialize();
            Player = EntityManager.Create<Player>();
        }
    }
}
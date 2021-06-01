using NullRPG.GameObjects;
using NullRPG.GameObjects.Actors;
using NullRPG.GameObjects.World.Overworld;
using NullRPG.Managers;

namespace NullRPG
{
    public class GameSession
    {
        public Overworld Overworld { get; private set; }
        public Player Player { get; private set; }
        public PlayerActor PlayerActor { get; private set; }


        public GameSession()
        {
            IndexedKeybindingsManager.Initialize();

            Overworld = new Overworld();
            Player = new Player();
            PlayerActor = new PlayerActor();
            

        }
    }
}
using NullRPG.GameObjects;
using NullRPG.GameObjects.Worlds;
using NullRPG.ItemTypes;
using NullRPG.Managers;

namespace NullRPG
{
    public class GameSession
    {
        public Player Player { get; set; }
        public World World { get; set; }

        public GameSession()
        {
            IndexedKeybindingsManager.Initialize();
            // Probably shouldn't be here
            ItemManager.Add(WeaponItem.None());
            World = new Overworld();
            Player = EntityManager.Create<Player>();
        }
    }
}
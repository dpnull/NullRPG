using NullRPG.Managers;

namespace NullRPG.GameObjects.Worlds
{
    public class Overworld : World
    {
        public Overworld() : base("Overworld")
        {
            WorldManager.AddWorld(this);

            WorldManager.AddAreaToWorld<Overworld>(OverworldArea.Hometown());
            WorldManager.AddAreaToWorld<Overworld>(OverworldArea.Outskirts());

            SetLevels();
        }
    }
}
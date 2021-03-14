using NullRPG.Interfaces;
using System.Collections.Generic;

namespace NullRPG.GameObjects.Worlds
{
    public class OverworldLocation : Location
    {
        public OverworldLocation(string name, IWorldObject[] worldObjects, int minLevel = 0, int maxLevel = 0) : base(name, worldObjects, minLevel, maxLevel)
        {
        }

        public static OverworldLocation Blacksmith()
        {
            return new OverworldLocation("Blacksmith", null);
        }

        public static OverworldLocation Home()
        {
            return new OverworldLocation("Home", null);
        }

        public static OverworldLocation Forest()
        {
            return new OverworldLocation("Forest", new IWorldObject[] { TreeObject.Birchnut() });
        }

        public static OverworldLocation Cave()
        {
            return new OverworldLocation("Cave", null);
        }
    }
}
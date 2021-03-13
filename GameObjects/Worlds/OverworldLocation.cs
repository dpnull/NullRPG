using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Worlds
{
    public class OverworldLocation : Location
    {
        public OverworldLocation(string name, int minLevel = 0, int maxLevel = 0) : base(name, minLevel, maxLevel)
        {

        }

        public static OverworldLocation Blacksmith()
        {
            return new OverworldLocation("Blacksmith");
        }

        public static OverworldLocation Home()
        {
            return new OverworldLocation("Home");
        }

        public static OverworldLocation Forest()
        {
            return new OverworldLocation("Forest", 1, 3);
        }

        public static OverworldLocation Cave()
        {
            return new OverworldLocation("Cave", 2, 5);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Worlds
{
    public class OverworldLocation : Location
    {
        public OverworldLocation(string name, int level) : base(name, level)
        {

        }

        public static OverworldLocation Blacksmith()
        {
            return new OverworldLocation("Blacksmith", 1);
        }

        public static OverworldLocation Home()
        {
            return new OverworldLocation("Home", 1);
        }

        public static OverworldLocation Forest()
        {
            return new OverworldLocation("Forest", 1);
        }

        public static OverworldLocation Cave()
        {
            return new OverworldLocation("Cave", 3);
        }
    }
}

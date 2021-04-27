using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.World.Overworld
{
    public class OverworldLocations : BaseLocation
    {
        public OverworldLocations(string name) : base(name)
        {

        }

        public static OverworldLocations Home()
        {
            var home = new OverworldLocations("home");

            return home;
        }
    }
}

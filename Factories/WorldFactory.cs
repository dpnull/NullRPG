using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Factories
{
    public static class WorldFactory
    {
        public static World CreateWorld()
        {
            World world = new World();

            world.AddLocation(0, 0, "Home",
                "This is your house.");

            world.AddLocation(1, 0, "Forest", "The local forest.");
            world.AddLocation(2, 0, "Town", "The seemingly abandoned town.");
            world.AddLocation(3, 0, "Rocky Cave", "The entrance suggests it must be occupied by spiders.");            world.AddLocation(4, 0, "Oli's Den", "Where the worst of the worst beasts live.");

            return world;
        }
    }
}

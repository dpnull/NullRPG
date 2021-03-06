﻿using NullRPG.GameObjects.LocationObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.World.Overworld
{
    public class OverworldLocations : BaseLocation
    {
        // TOWN_START

        public OverworldLocations(string name, int level = 0) : base(name, level)
        {

        }

        public static OverworldLocations Home()
        {
            var home = new OverworldLocations("Home");

            return home;
        }

        public static OverworldLocations Blacksmith()
        {
            return new OverworldLocations("Blacksmith");
        }

        public static OverworldLocations Herbalist()
        {
            return new OverworldLocations("Herbalist");
        }

        // TOWN_END

        // OUTSKIRTS_START

        public static OverworldLocations Cave()
        {
            return new OverworldLocations("Cave", 3);
        }

        public static OverworldLocations Forest()
        {
            var forest = new OverworldLocations("Forest", 1);

            var locationObject = new LocationComponents.LocationObjectComponent();
            locationObject.AddObject(LocationObject.TreeBirchnut());

            forest.AddComponent(locationObject);

            return forest;
        }

        // OUTSKIRTS_END
    }
}

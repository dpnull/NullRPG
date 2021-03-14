using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.GameObjects
{
    public class Location : ILocation, IIndexable
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }

        public List<IWorldObject> WorldObjects { get; set; }

        public Location(string name, IWorldObject[] worldObjects, int minLevel, int maxLevel)
        {
            ObjectId = LocationManager.GetUniqueLocationId();

            LocationManager.AddLocation(this);

            Name = name;
            MinLevel = minLevel;
            MaxLevel = maxLevel;

            WorldObjects = worldObjects;
        }

        public void AddWorldObject(IWorldObject worldObject)
        {
            WorldObjects.Add(worldObject);
        }

    }
}
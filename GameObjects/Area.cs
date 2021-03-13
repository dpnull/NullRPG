using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Collections.Generic;

namespace NullRPG.GameObjects
{
    public class Area : IArea, IIndexable
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public Dictionary<int, ILocation> Locations { get; set; }

        public Area(string name)
        {
            ObjectId = AreaManager.GetUniqueAreaId();
            AreaManager.Add(this);
            Name = name;
            Locations = new Dictionary<int, ILocation>();
        }

        public void AddLocation(ILocation location)
        {
            Locations.Add(location.ObjectId, location);
        }
    }
}
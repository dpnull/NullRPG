using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class Location : ILocation, IIndexable
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }

        public Location(string name, int minLevel, int maxLevel)
        {
            ObjectId = LocationManager.GetUniqueLocationId();

            LocationManager.AddLocation(this);

            Name = name;
            MinLevel = minLevel;
            MaxLevel = maxLevel;
        
        }
    }
}
using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface IArea
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public Dictionary<int, ILocation> Locations { get; set; }
    }
}
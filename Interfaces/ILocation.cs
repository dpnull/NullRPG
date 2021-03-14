using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface ILocation : IDrawableKeybinding
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public List<IWorldObject> WorldObjects { get; set; }
    }
}
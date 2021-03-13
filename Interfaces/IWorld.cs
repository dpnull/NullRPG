using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface IWorld
    {
        // possibly needs objectId?
        public string Name { get; set; }

        public Dictionary<int, IArea> Areas { get; set; }

        public int GetUniqueAreaId();
    }
}
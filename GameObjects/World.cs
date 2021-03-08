using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class World : IWorld
    {
        public string Name { get; set; }
        public Dictionary<int, IArea> Areas { get; set; }

        public World(string name)
        {
            Name = name;
            Areas = new Dictionary<int, IArea>();
        }

        private int _currentId;
        public int GetUniqueAreaId()
        {
            return _currentId++;
        }
    }
}

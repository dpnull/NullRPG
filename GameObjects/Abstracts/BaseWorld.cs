using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseWorld : IWorld
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public Dictionary<int, IArea> Areas { get; set; } = new Dictionary<int, IArea>();

        public BaseWorld(string name)
        {
            ObjectId = WorldManager.GetUniqueId();
            WorldManager.AddWorld(this);

            Name = name;
        }
    }
}

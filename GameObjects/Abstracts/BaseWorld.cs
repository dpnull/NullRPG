using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseWorld : ComponentSystemEntity, IWorld
    {
        public Dictionary<int, IArea> Areas { get; set; } = new Dictionary<int, IArea>();
        public BaseWorld(string name) : base(name)
        {
            ECSManager.AddEntity(this);
        }
    }
}

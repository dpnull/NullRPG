using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseArea : ComponentSystemEntity, IArea
    {
        public Dictionary<int, ILocation> Locations { get; set; } = new Dictionary<int, ILocation>();

        public BaseArea(string name) : base(name)
        {
            ECSManager.AddEntity(this);
        }
    }
}

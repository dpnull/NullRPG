using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.Entity
{
    public class PositionComponentValue
    {
        public ILocation Location;
        public IArea Area;
        public IWorld World;

        public PositionComponentValue(IWorld world, IArea area, ILocation location)
        {
            World = world;
            Area = area;
            Location = location;
        }
    }
}

using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.Entity
{
    class PositionComponent : IEntityComponent
    {
        public ILocation Location { get; set; }
        public IArea Area { get; set; }
        public IWorld World { get; set; }
        public IEntity Source { get; set; }

        public PositionComponent(IEntity source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            PositionComponentValue positionComponent = value as PositionComponentValue;
            if (positionComponent != null)
            {
                Location = positionComponent.Location;
                Area = positionComponent.Area;
                World = positionComponent.World;
            }

        }
    }
}

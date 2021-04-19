using NullRPG.GameObjects.LocationObjects;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.LocationComponent
{
    public class ChoppableComponent : ILocationComponent
    {
        public TreeObject TreeObject { get; private set; }
        public ILocation Source { get; set; }

        public ChoppableComponent(ILocation source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            ChoppableComponentValue choppableComponentValue = value as ChoppableComponentValue;
            if (choppableComponentValue != null)
            {
                TreeObject = choppableComponentValue.TreeObject;
            }
        }
    }
}

using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class BaseLocation : ILocation
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public List<ILocationComponent> Components { get; set; } = new List<ILocationComponent>();

        public BaseLocation(string name, int level)
        {
            ObjectId = LocationManager.GetUniqueLocationId();
            LocationManager.AddLocation(this);

            Name = name;
            Level = level;
        }

        public void ReceiveComponentValue<T>(T value)
        {
            foreach(ILocationComponent component in Components)
            {
                component.ReceiveValue(value);
            }
        }

        public T GetComponent<T>() where T : ILocationComponent
        {
            return Components.OfType<T>().FirstOrDefault();
        }


    }
}

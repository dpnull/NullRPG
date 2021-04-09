using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Locations
{
    public class OutskirtsLocations : BaseLocation
    {
        public OutskirtsLocations(string name) : base(name)
        {

        }

        public static OutskirtsLocations Forest()
        {
            return new OutskirtsLocations("Forest");
        }
    }
}

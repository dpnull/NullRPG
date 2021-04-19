using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Locations
{
    public class OutskirtsLocations : BaseLocation
    {
        public OutskirtsLocations(string name, int level) : base(name, level)
        {

        }

        public static OutskirtsLocations Forest()
        {
            var forest = new OutskirtsLocations("Forest", 1);
            
            //FINISH
        }

        public static OutskirtsLocations Cave()
        {
            return new OutskirtsLocations("Cave", 3);
        }
    }
}

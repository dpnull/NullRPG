using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Locations
{
    public class HometownLocations : BaseLocation
    {
        public HometownLocations(string name) : base(name, 0)
        {

        }

        public static HometownLocations Blacksmith()
        {
            return new HometownLocations("Blacksmith");
        }

        public static HometownLocations PlayerHome()
        {
            return new HometownLocations("Shed");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Locations
{
    public class HometownLocations : BaseArea
    {
        public HometownLocations(string name) : base(name)
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

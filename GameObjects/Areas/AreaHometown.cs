using NullRPG.GameObjects.Locations;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Areas
{
    public class AreaHometown : BaseArea
    {
        public AreaHometown() : base("Hometown")
        {
            AreaManager.AddLocationToArea(this, HometownLocations.PlayerHome());
            AreaManager.AddLocationToArea(this, HometownLocations.Blacksmith());
        }
    }
}

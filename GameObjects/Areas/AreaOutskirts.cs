using NullRPG.GameObjects.Locations;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Areas
{
    public class AreaOutskirts : BaseArea
    {
        public AreaOutskirts() : base("Outskirts")
        {
            AreaManager.AddLocationToArea(this, OutskirtsLocations.Forest());
        }
    }
}

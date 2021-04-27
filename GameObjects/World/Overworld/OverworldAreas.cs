using NullRPG.GameObjects.Abstracts;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.World.Overworld
{
    public class OverworldAreas : BaseArea
    {
        public OverworldAreas(string name) : base(name)
        {

        }

        public static OverworldAreas Town()
        {
            var town = new OverworldAreas("Town");
            AreaManager.AddLocationToArea<IArea, ILocation>(town, OverworldLocations.Home());
            return town;
        }
    }
}

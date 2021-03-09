using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class Area : IArea, IIndexable
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public Dictionary<int, ILocation> Locations { get; set; }

        public Area(string name)
        {
            ObjectId = AreaManager.GetUniqueAreaId();
            AreaManager.Add(this);
            Name = name;
            Locations = new Dictionary<int, ILocation>();           
        }

        public void AddLocation(ILocation location)
        {
            Locations.Add(location.ObjectId, location);
        }
    }
}

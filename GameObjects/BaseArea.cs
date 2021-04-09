using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class BaseArea : IArea
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public Dictionary<int, ILocation> Locations { get; set; } = new Dictionary<int, ILocation>();

        public BaseArea(string name)
        {
            ObjectId = AreaManager.GetUniqueAreaId();
            AreaManager.AddArea(this);

            Name = name;
        }
    }
}

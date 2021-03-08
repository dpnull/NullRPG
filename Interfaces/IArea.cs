using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IArea
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public Dictionary<int, ILocation> Locations { get; set; }
    }
}

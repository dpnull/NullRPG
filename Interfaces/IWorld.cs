using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IWorld
    {
        // possibly needs objectId?
        public string Name { get; set; }      
        public Dictionary<int, IArea> Areas { get; set; }
        public int GetUniqueAreaId();
    }
}

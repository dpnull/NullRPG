using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IArea : IComponentSystemEntity
    {
        // int ObjectId { get; }
        // string Name { get; }

        Dictionary<int, ILocation> Locations { get; set; }
    }
}

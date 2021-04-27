using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IWorld
    {
        int ObjectId { get; }
        string Name { get; }

        Dictionary<int, IArea> Areas { get; set; }
    }
}

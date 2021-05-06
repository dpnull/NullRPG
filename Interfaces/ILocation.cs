using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ILocation : IComponentSystemEntity
    {
        //int ObjectId { get; }
        //string Name { get; }
        int Level { get; }
    }
}

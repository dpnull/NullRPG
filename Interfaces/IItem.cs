using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IItem : IComponentSystemEntity
    {
        // string Name { get; }
        // int ObjectId { get; }
        bool IsStackable { get; }

    }
}

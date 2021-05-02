using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ILocationObject
    {
        int ObjectId { get; }
        string Name { get; }
        List<Enums.ActionTypes> ActionTypes { get; }

        bool HasComponent<T>();
        T GetComponent<T>();
    }
}

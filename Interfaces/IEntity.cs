using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IEntity
    {
        int ObjectId { get; }
        string Name { get; }
        T GetComponent<T>();
        bool HasComponent<T>();
    }
}

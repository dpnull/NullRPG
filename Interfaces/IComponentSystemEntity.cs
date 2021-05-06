using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{
    /*
    Interface re-implementation must occur for this interface.
    */
    public interface IComponentSystemEntity : IIndexable
    {

        string Name { get; set; }
        int ObjectId { get; }
        int TotalComponents { get; }
        bool IsEnabled { get; }

        List<IComponent> Components { get; set; }

        bool HasComponent<T>();
        void AddComponent<T>(T component) where T : IComponent;
        T GetComponent<T>();
        void RemoveComponent<T>();


    }
}

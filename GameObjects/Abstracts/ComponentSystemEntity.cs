using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{

    public abstract class ComponentSystemEntity : IComponentSystemEntity
    {
        public string Name { get; set; }
        public int ObjectId { get; }

        public ComponentSystemEntity(string name)
        {
            ObjectId = ECSManager.GetUniqueId();
            ECSManager.AddEntity(this);

            Name = name;
        }

        private int _totalComponents;
        private bool _isEnabled;

        public int TotalComponents { get { return _totalComponents; } }
        public bool IsEnabled { get { return _isEnabled; } }

        public List<IComponent> Components { get; set; } = new List<IComponent>();

        public void AddComponent<T>(T component) where T : IComponent
        {
            if (!Components.OfType<T>().Any())
            {
                Components.Add(component);
            }
            else if (Components.OfType<T>().Any())
            {
                throw new SystemException($"Component of type {nameof(T)} exists already.");
            }
        }

        public T GetComponent<T>()
        {
            return Components.OfType<T>().FirstOrDefault();
        }

        public bool HasComponent<T>()
        {
            if (Components.OfType<T>().Any())
            {
                return true;
            }
            return false;
        }

        public void RemoveComponent<T>()
        {
            throw new NotImplementedException();
        }
    }
}

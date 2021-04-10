using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Entity;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseEntity : IEntity
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public List<IEntityComponent> Components { get; set; } = new List<IEntityComponent>();

        /// <summary>
        /// Create a new instance of an entity with a unique id.
        /// </summary>
        /// <param name="name">A name for the entity.</param>
        public BaseEntity(string name)
        {
            Name = name;
            ObjectId = EntityManager.GetUniqueId();



        }

        public T GetComponent<T>() where T : IEntityComponent
        {
            return Components.OfType<T>().FirstOrDefault();
        }

        public void ReceiveComponentValue<T>(T value)
        {
            foreach (IEntityComponent component in Components)
            {
                component.ReceiveValue(value);
            }
        }
    }
}
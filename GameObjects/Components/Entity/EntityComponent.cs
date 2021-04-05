using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.Entity
{
    public class EntityComponent : IEntityComponent
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }

        public IEntity Source { get; set; }

        public EntityComponent(IEntity source)
        {
            Source = source;
        }

        public void ReceiveValue<T>(T value)
        {
            EntityComponentValue entityValue = value as EntityComponentValue;
            if (entityValue != null)
            {
                Health = entityValue.Health;
                MaxHealth = entityValue.MaxHealth;
                Defense = entityValue.Defense;
                Gold = entityValue.Gold;
            }
        }
    }
}

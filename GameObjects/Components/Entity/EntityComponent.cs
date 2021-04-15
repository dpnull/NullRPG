using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Components.Entity
{
    public class EntityComponent : IEntityComponent
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Defense { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int ExperienceRequired { get; set; }

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
                Level = entityValue.Level;
                Experience = entityValue.Experience;
                ExperienceRequired = entityValue.ExperienceRequired;
            }
        }
    }
}
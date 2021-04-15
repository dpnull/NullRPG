namespace NullRPG.GameObjects.Components.Entity
{
    public class EntityComponentValue
    {
        public int Health;
        public int MaxHealth;
        public int Defense;
        public int Gold;
        public int Level;
        public int Experience;
        public int ExperienceRequired;
        public EntityComponentValue(int health, int defense, int gold, int level = 1, int experience = 0, int experienceRequired = 0)
        {
            Health = health;
            MaxHealth = Health;
            Defense = defense;
            Gold = gold;
            Level = level;
            Experience = experience;
            ExperienceRequired = experienceRequired;
        }
    }
}
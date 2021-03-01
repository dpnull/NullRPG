using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Managers;
using NullRPG.ItemTypes;

namespace NullRPG.GameObjects
{
    public abstract class Entity : IEntity
    {
        public int ObjectId { get; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
        public WeaponItem CurrentWeapon { get; set; }

        public Entity(string name, int health, int gold, int level)
        {
            ObjectId = EntityManager.GetUniqueId();
            Name = name;
            Health = health;
            Gold = gold;
            Level = level;

            MaxHealth = Health;
            MinDmg = 0;
            MaxDmg = 0;
            Defense = 0;
        }
    }
}

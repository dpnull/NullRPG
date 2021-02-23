using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Entity : IEntity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public Inventory Inventory { get; set; }

        public bool IsDead => Health <= 0;

        protected Entity(string name, int maxHealth, int health, int gold)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = health;
            Gold = gold;

            Inventory = new Inventory();
        }

        public void AddGold(int amount)
        {
            Gold += amount;
        }
    }
}

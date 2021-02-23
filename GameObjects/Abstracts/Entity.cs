using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Entity : IEntity
    {
        private int _minDmg;
        private int _maxDmg;

        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public int Defense { get; set; }
        public Inventory Inventory { get; set; }

        public int MinDmg
        {
            get { return _minDmg + Inventory.GetCurrentWeapon().MinDmg; }
            set { _minDmg = value; }
        }
        public int MaxDmg
        {
            get { return _maxDmg + Inventory.GetCurrentWeapon().MaxDmg; }
            set { _maxDmg = value; }
        }

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

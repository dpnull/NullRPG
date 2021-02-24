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
        private int _defense;
        private int _maxHealth;

        public string Name { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public int MaxHealth
        {
            get { return _maxHealth + Inventory.GetCurrentHeadItem().Health + Inventory.GetCurrentBodyItem().Health; }
            set { _maxHealth = value; }
        }
        public int Defense
        {
            get { return _defense + Inventory.GetCurrentHeadItem().Defense + Inventory.GetCurrentBodyItem().Defense + Inventory.GetCurrentLegsItem().Defense; }
            set { _defense = value; }
        }
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

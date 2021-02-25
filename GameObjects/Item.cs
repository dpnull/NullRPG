using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace NullRPG.GameObjects
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public bool IsUnique { get; set; }
        public Color Color { get; set; }

        public Item(int id, string name, string description, int gold, int level = 1, int minDmg = 0, int maxDmg = 0, int defense = 0, int health = 0, bool isUnique = false)
        {
            ID = id;
            Name = name;
            Description = description;
            Level = level;
            Gold = gold;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Defense = defense;
            IsUnique = isUnique;
            Health = health;
            Color = Color.White;
        }
    }
}

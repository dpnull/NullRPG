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
        public int Gold { get; set; }
        public int Level { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public bool IsUnique { get; set; }
        public Color Color { get; set; }

        public Item CreateGatherableItem(int id, string name, int gold, bool isUnique = false)
        {
            ID = id;
            Name = name;
            Gold = gold;
            IsUnique = isUnique;
            Color = Color.White;

            Level = 0;           
            MinDmg = 0;
            MaxDmg = 0;
            Defense = 0;          
            Health = 0;


            return this;
        }
    }
}

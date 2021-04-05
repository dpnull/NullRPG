using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.Entity
{
    public class EntityComponentValue
    {
        public int Health;
        public int MaxHealth;
        public int Defense;
        public int Gold;

        public EntityComponentValue(int health, int defense, int gold)
        {
            Health = health;
            MaxHealth = Health;
            Defense = defense;
            Gold = gold;
        }
    }
}

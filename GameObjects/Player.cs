using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.GameObjects.Abstracts;

namespace NullRPG.GameObjects
{
    public class Player : Entity
    {
        public Player(string name, int health, int maxHealth, int gold) : base(name, health, maxHealth, gold)
        {
        }
    }
}

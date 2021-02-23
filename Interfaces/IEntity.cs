using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Interfaces
{
    public interface IEntity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
    }
}

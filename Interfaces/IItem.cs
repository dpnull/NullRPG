using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Interfaces
{
    public interface IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
        public bool IsUnique { get; set; }
    }
}

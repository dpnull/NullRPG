using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public class Player : Entity
    {
        public int Experience { get; set; }
        public int ExperienceNeeded { get; set; }
        public Player() : base("Tianyu", 100, 20)
        {
            Experience = 0;
            ExperienceNeeded = 100;
        }
    }
}

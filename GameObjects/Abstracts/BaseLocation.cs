﻿using NullRPG.GameObjects.Abstracts;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.World
{
    public abstract class BaseLocation : ComponentSystemEntity, ILocation
    {
        public int Level { get; set; }
        public BaseLocation(string name, int level = 0) : base(name)
        {
            Level = level;
            ECSManager.AddEntity(this);
        }
    }
}

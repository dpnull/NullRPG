﻿using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Worlds
{
    public class Overworld : World
    {
        public Overworld() : base("Overworld")
        {
            WorldManager.AddWorld(this);

            WorldManager.AddAreaToWorld<Overworld>(OverworldArea.Hometown());
            WorldManager.AddAreaToWorld<Overworld>(OverworldArea.Outskirts());
     
        }
    }
}

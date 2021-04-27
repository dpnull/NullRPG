using NullRPG.GameObjects.Abstracts;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.World.Overworld
{
    public class Overworld : BaseWorld
    {
        public Overworld() : base("Overworld")
        {
            WorldManager.AddAreaToWorld<IWorld, IArea>(this, OverworldAreas.Town());
        }


    }
}

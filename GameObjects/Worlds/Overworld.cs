using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Areas;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Worlds
{
    public class Overworld : BaseWorld
    {
        public Overworld() : base("Overworld")
        {
            WorldManager.AddAreaToWorld(this, new AreaOutskirts());
            WorldManager.AddAreaToWorld(this, new AreaHometown());
        }
    }
}

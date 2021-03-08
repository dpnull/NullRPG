using NullRPG.Interfaces;
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
            WorldManager.Add(this);

            WorldManager.AddArea<Overworld>(OverworldArea.Hometown());
     
        }
    }
}

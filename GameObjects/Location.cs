using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanGather { get; set; }
        public List<Item> Gathereable { get; set; }

        public void Gather()
        {
            Gathereable = new List<Item>();

            Gathereable = 

        }
    }
}
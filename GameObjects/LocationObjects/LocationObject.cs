using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.World;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.LocationObjects
{
    public class LocationObject : BaseLocationObject
    {
        public LocationObject(string name) : base(name)
        {
            LocationObjectManager.AddLocationObject(this);
        }
    }
}

using NullRPG.GameObjects.Inventory;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseLocationObject : ComponentSystemEntity, ILocationObject
    {
        public BaseLocationObject(string name) : base(name, LocationObjectManager.GetUniqueLocationObjectId())
        {
            var inventory = new EntityComponents.Inventory(new EntityInventory());

            AddComponent(inventory);
        }
    }
}

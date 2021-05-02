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
        public List<Enums.ActionTypes> ActionTypes { get; }
        public BaseLocationObject(string name, List<Enums.ActionTypes> actionTypes) : base(name, LocationObjectManager.GetUniqueLocationObjectId())
        {
            ActionTypes = actionTypes;

            LocationObjectManager.AddLocationObject(this);

            var inventory = new EntityComponents.Inventory();

            AddComponent(inventory);
        }

        public void AddItem(IItem item)
        {
            InventoryManager.AddToInventory(this, item);
        }
    }
}

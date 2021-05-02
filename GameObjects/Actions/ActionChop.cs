using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Actions
{
    public class ActionChop : BaseLocationAction
    {
        public ILocation Location { get; set; }
        public IEntity Entity { get; set; }

        private const Enums.ActionTypes ACTION_CHOP = Enums.ActionTypes.Chop;

        public ActionChop(ILocation location, IEntity entity) : base()
        {
            Location = location;
            Entity = entity;
        }

        public bool CanInteract()
        {
            if (Location.HasComponent<LocationComponents.LocationObjectComponent>())
            {
                return true;
            }
            return false;
        }

        public void OnInteract()
        {
            if (CanInteract())
            {
                if (HasActionType(Location, ACTION_CHOP))
                {
                    var locObject = GetLocationObject(Location, ACTION_CHOP);
                    var locObjectInventory = InventoryManager.GetEntityInventory((IComponentSystemEntity)locObject);
                    var obtainable = ItemManager.Get<IItem>(locObjectInventory.Slots.Values.FirstOrDefault().Item.FirstOrDefault().ObjectId);
                    InventoryManager.AddToInventory((IComponentSystemEntity)Entity, obtainable);
                }
            }
        }
    }
}

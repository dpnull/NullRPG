using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Actions
{
    public abstract class BaseLocationAction
    {
        public BaseLocationAction()
        {

        }

        public virtual bool HasActionType(ILocation location, Enums.ActionTypes actionType)
        {
            foreach (var obj in location.GetComponent<LocationComponents.LocationObjectComponent>().LocationObjects)
            {
                if (obj.ActionTypes.Contains(actionType))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual ILocationObject GetLocationObject(ILocation location, Enums.ActionTypes actionType)
        {
            foreach(var obj in location.GetComponent<LocationComponents.LocationObjectComponent>().LocationObjects)
            {
                return HasActionType(location, actionType) ? obj : null;
            }

            return null;
        }
    }
}

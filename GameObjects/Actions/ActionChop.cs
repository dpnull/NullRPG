using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Actions
{
    public class ActionChop : BaseAction
    {
        private ILocation _location;
        private IEntity _entity;

        public ActionChop(ILocation location, IEntity entity) : base()
        {

        }

        public override bool CanInteract()
        {
            if (_location.HasComponent<LocationComponents.LocationObjectComponent>())
            {
                return true;
            }
            return false;
        }

        public override void OnInteract()
        {
            if (CanInteract())
            {
                var obtainable = _location.GetComponent<LocationComponents.LocationObjectComponent>().
                    LocationObjects///////////TODO its a list
            }
        }
    }
}

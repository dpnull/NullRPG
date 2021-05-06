using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Items;
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
        public LocationObject(string name, List<Enums.ActionTypes> actionTypes) : base(name, actionTypes)
        {
            ECSManager.AddEntity(this);

        }

        public static LocationObject TreeBirchnut()
        {
            var birchnut = new LocationObject("Birchnut", new List<Enums.ActionTypes> { Enums.ActionTypes.Chop });
            birchnut.AddItem(Miscellaneous.Birchwood());
            return birchnut;
        }
    }
}

using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class AttributeManager
    {

        public static void PrintWeapon<T>(int objectId, T attributeType)
        {
            var item = ItemManager.GetItem<IItem>(objectId);
        }

    }
}

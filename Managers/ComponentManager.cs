using NullRPG.GameObjects.Abstracts;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class ComponentManager
    {
        public static bool HasItemProperty(IItem item, Enums.ItemProperties property)
        {
            if (item.HasComponent<ItemComponents.PropertyComponent>())
            {
                foreach (var p in item.GetComponent<ItemComponents.PropertyComponent>().Properties)
                    return true && p == property;
            } else
            {
                throw new System.Exception($"{nameof(item)} missing {nameof(ItemComponents.PropertyComponent)}.");
            }

            return false;
        }
    }
}

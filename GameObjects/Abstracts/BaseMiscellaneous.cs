using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseMiscellaneous : BaseItem
    {
        public BaseMiscellaneous(string name, int value, int level) : base(name, isStackable: true, value, level)
        {
            var properties = new ItemComponents.PropertyComponent();

            AddComponent(properties);
        }

        public void AddProperty(Enums.ItemProperties property)
        {
            if (!GetComponent<ItemComponents.PropertyComponent>().Properties.Contains(property))
            {
                GetComponent<ItemComponents.PropertyComponent>().AddProperty(property);
            }           
        }
    }
}

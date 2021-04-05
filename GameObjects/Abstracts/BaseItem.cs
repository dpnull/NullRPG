using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseItem : IItem
    {
        /*
         Note: the first item sub type attribute will always be displayed for the item on the preview.
         */
        public int ObjectId { get; set; }
        public string Name { get; set; } = "\0";
        public Enums.ItemCategories ItemType { get; set; }
        public int Value { get; set; } = 0;
        public bool IsStackable { get; set; } = false;
        //public bool CanEquip { get; set; } = false;
        //public bool CanStack { get; set; } = false;
        public List<IItemComponent> Components { get; set; } = new List<IItemComponent>();

        public BaseItem(string name, Enums.ItemCategories itemType)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);
            
            Name = name;
            ItemType = itemType;
        }

        public void ReceiveComponentValue<T>(T value)
        {
            foreach (IItemComponent component in Components)
            {
                component.ReceiveValue<T>(value);
            }
        }

        public T GetComponent<T>() where T : IItemComponent
        {
            return Components.OfType<T>().FirstOrDefault();
        }
    }
}

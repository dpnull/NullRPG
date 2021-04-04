using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Item : IItem
    {
        public int ObjectId { get; set; }
        public string Name { get; set; } = "\0";
        public Enums.ItemTypes ItemType { get; set; }
        public int Value { get; set; } = 0;
        //public bool CanEquip { get; set; } = false;
        //public bool CanStack { get; set; } = false;
        public List<IAttribute> Components { get; set; } = new List<IAttribute>();

        public Item(string name, Enums.ItemTypes itemType)
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);
            
            Name = name;
            ItemType = itemType;
        }

        public void ReceiveMessage<T>(T message)
        {
            foreach (IAttribute attribute in Components)
            {
                attribute.ReceiveMessage<T>(message);
            }
        }

        public T GetAttribute<T>() where T : IAttribute
        {
            return Components.OfType<T>().FirstOrDefault();
        }
    }
}

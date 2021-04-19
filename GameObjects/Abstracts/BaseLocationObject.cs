using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseLocationObject : ILocationObject
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public List<IItem> Items { get; set; }

        public BaseLocationObject(string name)
        {
            ObjectId = LocationObjectManager.GetUniqueLocationObjectId();
            LocationObjectManager.AddLocationObject(this);

            Name = name;
            Items = new List<IItem>();
        }

        public virtual void OnAction()
        {
            throw new NotImplementedException();
        }

        public void AddItem(IItem item)
        {
            Items.Add(item);
        }
    }
}

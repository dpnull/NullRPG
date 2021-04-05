using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IItem
    {
        int ObjectId { get; set; }
        Enums.ItemCategories ItemType { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        //bool CanEquip { get; set; }
        bool IsStackable { get; set; }
        public List<IItemComponent> Components { get; set; }
        void ReceiveComponentValue<T>(T message);
        public T GetComponent<T>() where T : IItemComponent;
    }
}

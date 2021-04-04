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
        Enums.ItemTypes ItemType { get; set; }
        string Name { get; set; }
        //int Value { get; set; }
        //bool CanEquip { get; set; }
        //bool CanStack { get; set; }
        public List<IAttribute> Components { get; set; }
        void ReceiveMessage<T>(T message);
        public T GetAttribute<T>() where T : IAttribute;
    }
}

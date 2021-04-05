using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IEntity
    {
        int ObjectId { get; set; }
        public string Name { get; set; }
        public List<IEntityComponent> Components { get; set; }
        void ReceiveComponentValue<T>(T value);
        public T GetComponent<T>() where T : IEntityComponent;
    }
}

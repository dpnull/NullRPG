using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NullRPG.GameObjects.WorldObjectBase;

namespace NullRPG.Interfaces
{
    public interface IWorldObject
    {
        public int ObjectId { get; set; }
        public List<IItem> Items { get; set; }
        public Objects ObjectType { get; set; }
        public ObjectActions ObjectActionType { get; set; }
    }
}

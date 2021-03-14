using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IWorldObject
    {
        public int ObjectId { get; set; }
        public IItem[] Items { get; set; }
    }
}

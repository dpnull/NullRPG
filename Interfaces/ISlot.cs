using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ISlot : IIndexable
    {
        public int ObjectId { get; set; }
        List<IItem> Item { get; set; }

    }
}

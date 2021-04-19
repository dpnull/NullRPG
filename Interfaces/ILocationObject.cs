using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ILocationObject
    {
        string Name { get; set; }
        int ObjectId { get; set; }
        List<IItem> Items { get; set; }
        void OnAction();
    }
}

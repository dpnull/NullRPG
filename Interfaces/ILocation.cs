using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ILocation
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }
}

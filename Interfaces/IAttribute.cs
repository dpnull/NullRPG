using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IAttribute
    {
        IItem Source { get; set; }
        void ReceiveMessage<T>(T message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IMessage
    {
        int ObjectId { get; set; }
        SadConsole.ColoredString ColoredString { get; set; }
    }
}

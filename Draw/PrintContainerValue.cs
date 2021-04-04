using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Draw
{
    public class PrintContainerValue
    {
        public ColoredString ColoredString { get; set; }
        public int Offset { get; set; }

        public PrintContainerValue(ColoredString coloredString, int offset)
        {
            ColoredString = coloredString;
            Offset = offset;
        }
    }
}

using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Draw
{
    public class PrintContainerItem
    {
        public List<PrintContainerValue> ItemValues { get; set; } = new List<PrintContainerValue>();

        public PrintContainerItem(IEnumerable<PrintContainerValue> values)
        {
            foreach (var value in values)
            {
                ItemValues.Add(value);
            }
        }

    }
}

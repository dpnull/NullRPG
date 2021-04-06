using System.Collections.Generic;

namespace NullRPG.Draw
{
    public class PrintContainerItem
    {
        public List<PrintContainerValue> ItemValues { get; set; } = new List<PrintContainerValue>();

        /// <summary>
        /// Create a single value object
        /// </summary>
        /// <param name="values"></param>
        public PrintContainerItem(IEnumerable<PrintContainerValue> values)
        {
            foreach (var value in values)
            {
                ItemValues.Add(value);
            }
        }
    }
}
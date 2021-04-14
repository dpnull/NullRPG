using SadConsole;

namespace NullRPG.Draw
{
    public class PrintContainerValue
    {
#nullable enable
        public ColoredString? ColoredString { get; set; }
        public int Offset { get; set; }
#nullable disable
        /// <summary>
        /// Create a single ColoredString object to be stored in a list in <typeparamref name="PrintContainerItem"/>
        /// </summary>
        /// <param name="coloredString">The SadConsole colored string.</param>
        /// <param name="offset">The X coordinate offset.</param>
        public PrintContainerValue(ColoredString coloredString, int offset)
        {
            ColoredString = coloredString;
            Offset = offset;
        }
    }
}
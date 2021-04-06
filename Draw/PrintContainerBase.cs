using NullRPG.Input;
using NullRPG.Interfaces;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Draw
{
    public abstract class PrintContainerBase
    {
        public int XOffset { get; set; } = 0;
        public int YOffset { get; set; } = 0;
        // X offsets
        public int NameOffset { get; set; } = 0;
        public int IndexOffset { get; set; } = 0;
        public int TypeOffset { get; set; } = 0;
        public ColoredString Name { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public string Id { get; set; }
        public ButtonBase Button { get; set; }
        public IIndexedKeybinding[] Keybindings { get; set; }

        public List<PrintContainerItem> ContainerItems { get; set; } = new List<PrintContainerItem>();

        public PrintContainerBase(IIndexedKeybinding[] keybindings)
        {
            Keybindings = keybindings;
        }
    }
}

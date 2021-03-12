using NullRPG.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Windows.Navigation
{
    public static class KeybindingsWindowHelper
    {
        public static void DrawKeybindings(this SadConsole.Console console, ButtonString button)
        {
            button.Draw(console);
        }
    }
}

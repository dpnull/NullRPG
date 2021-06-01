using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole;
using SadConsole.Input;

using Console = SadConsole.Console;

namespace NullRPG.Input
{
    public class ButtonContainer
    {
        public List<IButton> Buttons { get; set; } = new List<IButton>();
        private Console _caller;
        public ButtonContainer(IUserInterface caller)
        {
            _caller = caller.Console;
        }

        public void DrawButtons()
        {
            foreach(var btn in Buttons)
            {
                btn.Draw(_caller);
            }
        }

        public void AddButton(Button button)
        {

        }
    }
}

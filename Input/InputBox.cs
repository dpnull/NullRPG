using NullRPG.Interfaces;
using NullRPG.Windows.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.Extensions;
using NullRPG.Managers;

namespace NullRPG.Input
{
    public class InputBox
    {
        private InputWindow inputWindow;
        private IInputBox _caller;

        //private IUserInterface _caller;
        public InputBox(IInputBox caller)
        {
            _caller = caller;
        }

        public void Init(IUserInterface console)
        {
            inputWindow = new InputWindow(_caller);

            UserInterfaceManager.Add(inputWindow);

            console.Console.Children.Add(inputWindow);

            inputWindow.TransitionConsole = console;

            console.Console.SwitchFocusMakeVisible(inputWindow);
        }

        public void Delete()
        {
            if (inputWindow.InputObtained)
            {
                UserInterfaceManager.Get<InputWindow>().Delete();
            }        
        }

    }
}

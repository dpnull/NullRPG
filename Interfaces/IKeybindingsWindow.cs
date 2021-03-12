using NullRPG.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IKeybindingsWindow
    {
        List<ButtonString> Buttons { get; set; }

        void OnDraw();
    }
}

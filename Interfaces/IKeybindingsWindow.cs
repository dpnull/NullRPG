using NullRPG.Input;
using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface IKeybindingsWindow
    {
        List<ButtonString> Buttons { get; set; }

        void OnDraw();
    }
}
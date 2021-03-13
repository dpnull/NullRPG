using NullRPG.Input;

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
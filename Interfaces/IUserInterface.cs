using Microsoft.Xna.Framework;
using Console = SadConsole.Console;

namespace NullRPG.Interfaces
{
    public interface IUserInterface
    {
        Point Position { get; set; }
        bool IsVisible { get; set; }
        bool IsDirty { get; set; }
        SadConsole.Console Console { get; }
    }
}

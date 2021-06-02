using SadConsole;

namespace NullRPG.Interfaces
{
    public interface IRenderable
    {
        void RenderObject(Console console);
        void UnRenderObject();
    }
}

using GoRogue;
using Microsoft.Xna.Framework;
using NullRPG.Map;
using SadConsole;

namespace NullRPG.Interfaces
{
    public interface IMapEntity : IRenderable
    {
        int ObjectId { get; }
        Console RenderConsole { get; }
        int CurrentBlueprintId { get; }
        FOV FieldOfView { get; }
        int FieldOfViewRadius { get; set; }
        Point Position { get; set; }
        int Glyph { get; }
        void ResetFieldOfView();
        void MoveToBlueprint(int blueprintId);
        void MoveToBlueprint<T>(Blueprint<T> blueprint) where T : MapCell, new();
    }
}

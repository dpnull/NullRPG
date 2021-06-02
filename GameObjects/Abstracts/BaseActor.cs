using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SadConsole;
using NullRPG.Interfaces;
using NullRPG.Managers;
using GoRogue;
using Console = SadConsole.Console;
using NullRPG.Map;
using NullRPG.GameObjects.Actors;
using static SadConsole.Entities.Entity;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseActor : ComponentSystemEntity, IMapEntity
    {
        public SadConsole.Entities.Entity Actor;

        public int FieldOfViewRadius { get; set; }

        private FOV _fieldOfView;
        public FOV FieldOfView
        {
            get
            {
                return _fieldOfView ??= new FOV(GridManager.Grid.FieldOfView);
            }
        }

        public int Glyph { get => Actor.Animation.CurrentFrame[0].Glyph; }

        public Direction Facing { get; private set; }

        public Console RenderConsole { get; private set; }

        public int CurrentBlueprintId { get; private set; }

        public Point Position { get; set; }

        /// <summary>
        /// Call this when the grid changes to a new grid object. (Like going into the basement etc)
        /// </summary>
        public void ResetFieldOfView()
        {
            _fieldOfView = null;
        }

        public void MoveToBlueprint<T>(Blueprint<T> blueprint) where T : MapCell, new()
        {
            CurrentBlueprintId = blueprint.ObjectId;

            // Reset field of view when we move to another blueprint
            ResetFieldOfView();

            if (!(this is PlayerActor))
            {
                Actor.IsVisible = Game.GameSession.PlayerActor != null && Game.GameSession.PlayerActor.CurrentBlueprintId == CurrentBlueprintId;
            }
        }

        public void MoveToBlueprint(int blueprintId)
        {
            CurrentBlueprintId = blueprintId;

            // Reset field of view when we move to another blueprint
            ResetFieldOfView();

            if (!(this is PlayerActor))
            {
                Actor.IsVisible = Game.GameSession.PlayerActor != null && Game.GameSession.PlayerActor.CurrentBlueprintId == CurrentBlueprintId;
            }
        }


        public BaseActor(Color foreground, Color background, int glyph) : base("Actor")
        {
            ECSManager.AddEntity(this);
            CreateActor(foreground, background, glyph);
        }

        private void CreateActor(Color foreground, Color background, int glyph, int width = 1, int height = 1)
        {
            Actor = new SadConsole.Entities.Entity(foreground, background, glyph);

            Actor.Animation.CurrentFrame[0].Foreground = foreground;
            Actor.Animation.CurrentFrame[0].Background = background;
            Actor.Animation.CurrentFrame[0].Glyph = glyph;
            // TO CONTINUE FROM HERE
        }

        public virtual void OnMove(object sender, EntityMovedEventArgs args)
        {
            if (this is IItem) return;

            // Re-calculate the field of view
            FieldOfView.Calculate(Actor.Position, FieldOfViewRadius);

            // Only update visual for player entity
            if (this is PlayerActor player)
            {
                // Center viewpoint on player
                player.MapWindow.CenterOnEntity(player);

                // Draw unexplored tiles always on by default for now
                GridManager.Grid.DrawFieldOfView(player, true);
            }
        }

        public bool CanMoveTowards(Point position)
        {
            var cell = GridManager.Grid.GetCell(position);
            return GridManager.Grid.InBounds(position) && cell.CellProperties.Walkable && !MapEntityManager.MapEntityExistsAt(position, CurrentBlueprintId) && cell.CellProperties.IsExplored;
        }

        public void MoveTowards(Point position, bool checkCanMove = true, Direction direction = null, bool triggerMovementEffects = true)
        {

            // Set correct facing direction regardless if we can move or not
            SetFacingDirection(position, direction);

            if (checkCanMove && !CanMoveTowards(position)) return;

            var oldPos = Position;
            Position = position;
        }

        private void SetFacingDirection(Point newPosition, Direction direction)
        {
            // Set facing direction
            var prevPos = Position;
            var difference = newPosition - prevPos;
            if (difference.X == 1 && difference.Y == 0)
                Facing = Direction.RIGHT;
            else if (difference.X == -1 && difference.Y == 0)
                Facing = Direction.LEFT;
            else if (difference.X == 0 && difference.Y == 1)
                Facing = Direction.DOWN;
            else if (difference.X == 0 && difference.Y == -1)
                Facing = Direction.UP;
            else
                Facing = direction ?? Direction.DOWN;
        }

        public void RenderObject(Console console)
        {
            RenderConsole = console;
            console.Children.Add(this.Actor);
        }

        public void UnRenderObject()
        {
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoRogue;
using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Actors;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Map;
using SadConsole;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseMapEntity : SadConsole.Entities.Entity, IMapEntity
    {
        public int ObjectId { get; }
        public int FieldOfViewRadius { get; set; }

        private FOV _fieldOfView;
        public FOV FieldOfView
        {
            get
            {
                return _fieldOfView ??= new FOV(GridManager.Grid.FieldOfView);
            }
        }

        public int Glyph { get => Animation.CurrentFrame[0].Glyph; }

        public Direction Facing { get; private set; }

        public Console RenderConsole { get; private set; }

        public int CurrentBlueprintId { get; private set; }


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
                IsVisible = Game.GameSession.PlayerActor != null && Game.GameSession.PlayerActor.CurrentBlueprintId == CurrentBlueprintId;
            }
        }

        public void MoveToBlueprint(int blueprintId)
        {
            CurrentBlueprintId = blueprintId;

            // Reset field of view when we move to another blueprint
            ResetFieldOfView();

            if (!(this is PlayerActor))
            {
                IsVisible = Game.GameSession.PlayerActor != null && Game.GameSession.PlayerActor.CurrentBlueprintId == CurrentBlueprintId;
            }
        }


        public BaseMapEntity(Color foreground, Color background, int glyph, Blueprint<MapCell> blueprint = null, int width = 1, int height = 1) : base(width, height)
        {
            //ECSManager.AddEntity(this);
            ObjectId = MapEntityManager.GetUniqueId();
            CurrentBlueprintId = blueprint != null ? blueprint.ObjectId : (GridManager.ActiveBlueprint != null ? GridManager.ActiveBlueprint.ObjectId : -1);

            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;

            Facing = Direction.DOWN;

            Moved += OnMove;
        }
        public virtual void OnMove(object sender, EntityMovedEventArgs args)
        {

            // Re-calculate the field of view
            FieldOfView.Calculate(Position, FieldOfViewRadius);

            // Only update visual for player entity
            if (this is PlayerActor player)
            {
                // Center viewpoint on player
                player.MapWindow.CenterOnEntity(player);

                // Draw unexplored tiles always on by default for now
                GridManager.Grid.DrawFieldOfView(player, true);
            }
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

        public bool CanMoveTowards(Point position)
        {
            var cell = GridManager.Grid.GetCell(position);
            return GridManager.Grid.InBounds(position) && cell.CellProperties.Walkable && !MapEntityManager.MapEntityExistsAt(position, CurrentBlueprintId) && cell.CellProperties.IsExplored;
        }

        public void MoveTowards(Direction position, bool checkCanMove = true)
        {
            var pos = Position;
            MoveTowards(pos += position, checkCanMove);
        }

        public void MoveTowards(Point position, bool checkCanMove = true, Direction direction = null, bool triggerMovementEffects = true)
        {

            // Set correct facing direction regardless if we can move or not
            SetFacingDirection(position, direction);

            if (checkCanMove && !CanMoveTowards(position)) return;

            Position = position;
        }

        public bool GetInteractedCell(out Point cellPosition)
        {
            cellPosition = default;
            //MessageManager.AddMessage($"Position: X{Position.X}, Y{Position.Y} | Facing: X{Facing.DeltaX}, Y{Facing.DeltaY}");
            var facingPosition = Position + Facing;
            if (CanInteract(facingPosition.X, facingPosition.Y))
            {
                cellPosition = new Point(facingPosition.X, facingPosition.Y);
                return true;
            }
            return false;
        }

        public bool CanInteract(int x, int y)
        {
            if (!GridManager.Grid.InBounds(x, y)) return false;
            var cell = GridManager.Grid.GetCell(x, y);
            MessageManager.AddMessage($"Position: X{Position.X}, Y{Position.Y} | Facing: X{Facing.DeltaX}, Y{Facing.DeltaY} Cell: {cell.CellProperties.Name} (X{cell.Position.X}, Y{cell.Position.Y})");
            return cell.CellProperties.Interactable && !MapEntityManager.MapEntityExistsAt(x, y, CurrentBlueprintId) && cell.CellProperties.IsExplored;
        }

        public void RenderObject(Console console)
        {
            RenderConsole = console;
            console.Children.Add(this);
        }

        public void UnRenderObject()
        {
            if (RenderConsole != null)
            {
                RenderConsole.Children.Remove(this);
                RenderConsole = null;
            }
        }
    }
}


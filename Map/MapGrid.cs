using NullRPG.Interfaces;
using GoRogue.MapViews;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Console = SadConsole.Console;
using NullRPG.Windows;
using NullRPG.Managers;

namespace NullRPG.Map
{
    public class MapGrid : IRenderable
    {
        protected MapCell[] Cells { get; }

        private ArrayMap<bool> _fieldOfView;
        public ArrayMap<bool> FieldOfView
        {
            get
            {
                if (_fieldOfView != null) return _fieldOfView;
                _fieldOfView = new ArrayMap<bool>(GridSizeX, GridSizeY);
                for (int x = 0; x < GridSizeX; x++)
                {
                    for (int y = 0; y < GridSizeY; y++)
                    {
                        var cell = GetNonClonedCell(x, y);
                        _fieldOfView[x, y] = !cell.CellProperties.BlocksFov;
                    }
                }
                return _fieldOfView;
            }
        }

        public int GridSizeX { get; }
        public int GridSizeY { get; }

        public Blueprint<MapCell> Blueprint { get; }

        private MapWindow _map;
        protected MapWindow Map
        {
            get
            {
                return _map ??= UserInterfaceManager.Get<MapWindow>();
            }
        }

        private Console _renderedConsole;

        public MapGrid(Blueprint<MapCell> blueprint)
        {
            GridSizeX = blueprint.GridSizeX;
            GridSizeY = blueprint.GridSizeY;
            Blueprint = blueprint;

            // init tiles
            GridManager.InitializeTiles();
            // init cells
            Cells = Blueprint.GetCells();
        }

        public MapGrid(int gridSizeX, int gridSizeY, MapCell[] cells, Blueprint<MapCell> blueprint = null)
        {
            GridSizeX = gridSizeX;
            GridSizeY = gridSizeY;
            Blueprint = blueprint;
            Cells = cells;
        }

        public IEnumerable<MapCell> GetCells(Func<MapCell, bool> criteria)
        {
            for (int x = 0; x < GridSizeX; x++)
            {
                for (int y = 0; y < GridSizeY; y++)
                {
                    if (criteria.Invoke(GetNonClonedCell(x, y)))
                    {
                        yield return GetCell(x, y);
                    }
                }
            }
        }

        public MapCell GetCell(Point position)
        {
            return Cells[position.Y * GridSizeX + position.X].Clone();
        }

        public MapCell GetCell(int x, int y)
        {
            return Cells[y + GridSizeX + x].Clone();
        }

        /// <summary>
        /// Retrieves the first cell that matches the given criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public MapCell GetCell(Func<MapCell, bool> criteria)
        {
            for (int x = 0; x < GridSizeX; x++)
            {
                for (int y = 0; y < GridSizeY; y++)
                {
                    if (criteria.Invoke(GetNonClonedCell(x, y)))
                    {
                        return GetCell(x, y);
                    }
                }
            }
            return null;
        }

        public bool ContainsEntity(Point position, int blueprintId)
        {
            return MapEntityManager.MapEntityExistsAt(position, blueprintId);
        }

        public bool ContainsEntity(int x, int y, int blueprintId)
        {
            return MapEntityManager.MapEntityExistsAt(x, y, blueprintId);
        }

        public void SetCell(MapCell cell, bool calculateEntitiesFov = false)
        {
            var originalCell = Cells[cell.Position.Y * GridSizeX + cell.Position.X];

            bool updateFieldOfView = originalCell.CellProperties.BlocksFov != cell.CellProperties.BlocksFov;

            originalCell.CopyFrom(cell);

            if (updateFieldOfView)
            {
            }
        }

        /// <summary>
        /// Updates the FieldOfView data for this cell.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected void UpdateFieldOfView(int x, int y)
        {
            var cell = GetNonClonedCell(x, y);
            FieldOfView[x, y] = !cell.CellProperties.BlocksFov;
        }

        /// <summary>
        /// Updates the FieldOfView data for the entire grid and all the entities.
        /// </summary>
        public void UpdateFieldOfView()
        {
            for (int x = 0; x < GridSizeX; x++)
            {
                for (int y = 0; y < GridSizeY; y++)
                {
                    var cell = GetNonClonedCell(x, y);
                    FieldOfView[x, y] = !cell.CellProperties.BlocksFov;
                }
            }
        }
        public IEnumerable<MapCell> GetCellsInFov(IMapEntity entity)
        {
            var cells = new List<MapCell>();
            for (int x = 0; x < GridSizeX; x++)
            {
                for (int y = 0; y < GridSizeY; y++)
                {
                    var cell = GetNonClonedCell(x, y);
                    if (entity.FieldOfView.BooleanFOV[x, y])
                        cells.Add(cell);
                }
            }
            return cells;
        }

        public IEnumerable<MapCell> GetCellsInFov(IMapEntity entity, int fovRadius)
        {
            var originalFov = entity.FieldOfViewRadius;

            entity.FieldOfViewRadius = fovRadius;
            MapEntityManager.RecalculatFieldOfView(entity, false);

            var cells = GetCellsInFov(entity).ToList();

            entity.FieldOfViewRadius = originalFov;
            MapEntityManager.RecalculatFieldOfView(entity, false);

            return cells;
        }

        public void DrawFieldOfView(IMapEntity entity, bool discoverUnexploredTiles = false)
        {
            var prevFov = entity.FieldOfViewRadius;

            entity.FieldOfViewRadius = Constants.Player.PLAYER_FOV;
            MapEntityManager.RecalculatFieldOfView(entity, false);

            // Actual cells we see
            foreach (var lightCell in GridManager.Grid.GetCellsInFov(entity))
            {
                var cell = GetNonClonedCell(lightCell.Position.X, lightCell.Position.Y);
                cell.CellProperties.IsExplored = true;
                cell.IsVisible = true;
            }

            // Reset entity fov
            if (prevFov != entity.FieldOfViewRadius)
            {
                entity.FieldOfViewRadius = prevFov;
                MapEntityManager.RecalculatFieldOfView(entity, false);
            }

            for (int x = 0; x < GridSizeX; x++)
            {
                for (int y = 0; y < GridSizeY; y++)
                {
                    var cell = GetNonClonedCell(x, y);

                    if (discoverUnexploredTiles && !cell.CellProperties.IsExplored)
                    {
                        if (entity.FieldOfView.BooleanFOV[x, y])
                        {
                            cell.CellProperties.IsExplored = true;
                        }
                    }

                    cell.IsVisible = cell.CellProperties.IsExplored;

                    SetCellColors(cell);
                    SetCell(cell);
                }
            }

            // Redraw the map
            if (Map != null)
            {
                Map.Update();
            }
        }

        public IEnumerable<MapCell> GetExploredCellsInFov(IMapEntity entity)
        {
            return GetCellsInFov(entity).Where(cell => cell.CellProperties.IsExplored);
        }

        public IEnumerable<MapCell> GetExploredCellsInFov(IMapEntity entity, int fovRadius)
        {
            return GetCellsInFov(entity, fovRadius).Where(cell => cell.CellProperties.IsExplored);
        }

        public void SetCellColors(MapCell cell)
        {
            cell.Foreground = cell.CellProperties.FovForeground;
            cell.Background = cell.CellProperties.FovBackground;
        }

        public bool InBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < GridSizeX && y < GridSizeY;
        }

        public bool InBounds(Point position)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < GridSizeX && position.Y < GridSizeY;
        }

        public void UnRenderObject()
        {
            if (_renderedConsole != null)
            {
                _renderedConsole.Clear();
                _renderedConsole = null;
            }
        }

        /// <summary>
        /// Use this when updating multiple cells at a time for performance.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected MapCell GetNonClonedCell(int x, int y)
        {
            return Cells[y * GridSizeX + x];
        }

        public void RenderObject(Console console)
        {
            _renderedConsole = console;
            console.SetSurface(Cells, GridSizeX, GridSizeY);
        }
    }
}

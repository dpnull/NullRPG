using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Actors;
using NullRPG.Map;
using NullRPG.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public class InteractionManager
    {
        //private readonly Player player;
        private readonly FovWindow _fovObjectsWindow;
        private readonly PlayerActor _player;

        public InteractionManager(PlayerActor player)
        {
            _fovObjectsWindow = UserInterfaceManager.Get<FovWindow>();
            this._player = player;
        }

        private class NameConstants
        {
            public const string DoorOpen = "Door Open";
            public const string DoorClosed = "Door Closed";
        }

        public void HandleInteraction(Point position)
        {
            var cell = GridManager.Grid.GetCell(position);
            string cellName = cell.CellProperties.Name;
            switch (cellName)
            {
                case NameConstants.DoorClosed:
                case NameConstants.DoorOpen:              
                    HandleDoorInteraction(cell);
                    break;
                default:
                    //HandleDefaultInteraction(cell);
                    break;
            }
        }

        private void HandleDoorInteraction(MapCell cell)
        {
            if (cell.CellProperties.Walkable)
            {
                cell.CellProperties.Walkable = false;
                cell.Glyph = '+';
                cell.CellProperties.BlocksFov = true;
            }
            else
            {
                cell.CellProperties.Walkable = true;
                cell.Glyph = '=';
                cell.CellProperties.BlocksFov = false;
            }
            GridManager.Grid.SetCell(cell);

            // Incase some effects need to be updated/shown after an interaction
            UpdateMapAfterInteraction();
        }

        private void UpdateMapAfterInteraction()
        {
            _player.FieldOfView.Calculate(_player.Position, _player.FieldOfViewRadius);

            // Unsure
            GridManager.Grid.DrawFieldOfView(_player, true);

            _player.MapWindow.Update();
            _fovObjectsWindow.Update(_player);
        }
    }
}

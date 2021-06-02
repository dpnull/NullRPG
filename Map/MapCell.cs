using Microsoft.Xna.Framework;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Map
{
    public class MapCell : Cell, IEquatable<MapCell>
    {
        public MapCellProperties CellProperties { get; set; }

        public Point Position { get; set; }

        public MapCell()
        {
            CellProperties = new MapCellProperties
            {
                RegularForeground = Color.White,
                RegularBackground = Color.Black,
                FovForeground = Color.DarkGray,
                FovBackground = Color.Black,
                Walkable = true,
                Interactable = false,
                BlocksFov = false,
                IsExplored = false
            };

            Glyph = ' ';
            Foreground = CellProperties.RegularBackground;
            Background = CellProperties.RegularForeground;
        }

        // Todo: implement more constructors

        public void CopyFrom(MapCell cell)
        {
            // Does foreground, background, glyph, mirror, decorators
            CopyAppearanceFrom(cell);

            // Base properties
            Position = cell.Position;
            // Ember cell properties
            CellProperties.Name = cell.CellProperties.Name;
            CellProperties.RegularForeground = cell.CellProperties.RegularForeground;
            CellProperties.RegularBackground = cell.CellProperties.RegularBackground;
            CellProperties.FovForeground = cell.CellProperties.FovForeground;
            CellProperties.Interactable = cell.CellProperties.Interactable;
            CellProperties.FovBackground = cell.CellProperties.FovBackground;
            CellProperties.Walkable = cell.CellProperties.Walkable;
            CellProperties.BlocksFov = cell.CellProperties.BlocksFov;
            CellProperties.IsExplored = cell.CellProperties.IsExplored;
        }

        public new MapCell Clone()
        {
            var cell = new MapCell()
            {
                CellProperties = new MapCellProperties()
                {
                    Name = this.CellProperties.Name,
                    RegularForeground = this.CellProperties.RegularForeground,
                    RegularBackground = this.CellProperties.RegularBackground,
                    FovForeground = this.CellProperties.FovForeground,
                    FovBackground = this.CellProperties.FovBackground,
                    Walkable = this.CellProperties.Walkable,
                    Interactable = this.CellProperties.Interactable,
                    BlocksFov = this.CellProperties.BlocksFov,
                    IsExplored = this.CellProperties.IsExplored
                },

                Position = this.Position,
            };
            // Does foreground, background, glyph, mirror, decorators
            CopyAppearanceTo(cell);
            return cell;
        }

        // implement bool containsentity

        // override for equals

        // gethashcode

        // get to string 

        public bool Equals(MapCell other)
        {
            throw new NotImplementedException();
        }

        public class MapCellProperties
        {
            public string Name { get; set; }
            public bool Walkable { get; set; }
            public bool Interactable { get; set; }
            public Color RegularForeground { get; set; }
            public Color FovForeground { get; set; }
            public Color RegularBackground { get; set; }
            public Color FovBackground { get; set; }
            public bool BlocksFov { get; set; }
            public bool IsExplored { get; set; }
        }
    }
}

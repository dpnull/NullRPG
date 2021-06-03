using Microsoft.Xna.Framework;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Map
{
    public class Tiles
    {
        public Tiles(Dictionary<char?, BlueprintTile> tiles)
        {
            InitTiles(tiles);
        }

        private static readonly List<BlueprintTile> _tiles = new List<BlueprintTile>();

        public static void InitTiles(Dictionary<char?, BlueprintTile> tiles)
        {
            AddTile("Empty", ' ', Color.Transparent, Color.Black, true, false, false);
            AddTile("Wall", '#', Color.Transparent, Color.Gray, false, false, true);
            AddTile("Tree", 'T', Color.Green, Color.Transparent, false, false, true);
            AddTile("GrassA", '.', Color.GreenYellow, Color.Transparent, true, false, false);
            AddTile("GrassB", ',', Color.GreenYellow, Color.Transparent, true, false, false);
            AddTile("Door Open", '=', Color.Brown, Color.Transparent, true, true, false);
            AddTile("Door Closed", '+', Color.Brown, Color.Transparent, false, true, true);

            foreach(var _tile in _tiles)
            {
                tiles.Add(_tile.Glyph, _tile);
            }
        }

        private static void AddTile(string name, char glyph, Color foreground, Color background, bool walkable, bool interactable, bool blocksFov)
        {
            _tiles.Add(
                new BlueprintTile
                {
                    Name = name,
                    Glyph = glyph,
                    Foreground = foreground,
                    Background = background,
                    Walkable = walkable,
                    Interactable = interactable,
                    BlocksFov = blocksFov,
                });
        }
    }
}

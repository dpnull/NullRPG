using NullRPG.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using SadConsole;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Console = SadConsole.Console;
using NullRPG.Map;
using NullRPG.Extensions;
using NullRPG.GameObjects.Actors;
using NullRPG.Managers;

namespace NullRPG.Windows
{
    class FovWindow : Console, IUserInterface
    {
        public Console Console => this;

        private readonly int _maxLineRows;
        private readonly Console _textConsole;
        //Recreated with ReinitializeCharObjects()
        private Dictionary<char, CharObj> _charObjects;
        private readonly Dictionary<char, BlueprintTile> _blueprintTiles;

        public FovWindow(int width, int height) : base(width, height)
        {

            this.DrawBorders(width, height, "O", "|", "-", Color.Gray);
            Print(3, 0, "Objects", Color.Orange);
            _charObjects = new Dictionary<char, CharObj>();
            _blueprintTiles = GetTiles();
            _maxLineRows = Height - 2;

            _textConsole = new Console(Width - 2, Height - 2)
            {
                Position = new Point(2, 1),
            };

            Position = new Point(Constants.Windows.FovX, Constants.Windows.FovY);

            Children.Add(_textConsole);
            Global.CurrentScreen.Children.Add(this);
        }

        private Dictionary<char, BlueprintTile> GetTiles()
        {
            var tiles = GridManager.GetTiles();

            var newDictionary = new Dictionary<char, BlueprintTile>();

            foreach(var tile in tiles)
            {
                if (tile.Key != null)
                {
                    newDictionary.Add((char)tile.Key, tile.Value);
                }
            }

            return newDictionary;
        }


        private void ReinitializeCharObjects(IEnumerable<char> characters, bool updateText = true)
        {
            _charObjects = new Dictionary<char, CharObj>(GetCharObjectPairs(characters));

            if (updateText)
                UpdateText();
        }

        private IEnumerable<KeyValuePair<char, CharObj>> GetCharObjectPairs(IEnumerable<char> characters)
        {
            foreach (var character in characters)
            {
                if (!_blueprintTiles.TryGetValue(character, out var tile) || tile.Name == null) continue;
                var glyphColor = tile.Foreground;
                //if (glyphColor.A == 0) continue; // Don't render transparent tiles on the fov window
                yield return new KeyValuePair<char, CharObj>(character, new CharObj(tile.Glyph, glyphColor, tile.Name));
            }
        }

        private void UpdateText()
        {
            _textConsole.Clear();
            _textConsole.Cursor.Position = new Point(0, 0);

            var orderedValues = _charObjects.OrderBy(x => x.Key).Select(pair => pair.Value);

            foreach (var charObj in orderedValues.Take(_maxLineRows - 1))
                DrawCharObj(charObj);

            if (_charObjects.Count > _maxLineRows)
                _textConsole.Cursor.Print("[More Objects..] [>]");
        }

        private void DrawCharObj(CharObj charObj)
        {
            //Debug.WriteLine(charObj.Name + ": " + charObj.Glyph);
            _textConsole.Cursor.Print(new ColoredString("[" + charObj.Glyph + "]:", charObj.GlyphColor, Color.Transparent));
            _textConsole.Cursor.Print(' ' + charObj.Name);
            _textConsole.Cursor.CarriageReturn();
            _textConsole.Cursor.LineFeed();
        }

        public void Update(IMapEntity entity)
        {
            int radius = entity is PlayerActor ? Constants.Player.PLAYER_FOV : entity.FieldOfViewRadius;

            // Gets cells player can see after FOV refresh.
            var cells = GridManager.Grid.GetExploredCellsInFov(entity)
                .Select(a => (char)a.Glyph)
                //Take only unique cells as an array.
                .Distinct();

            // Draw visible cells to the FOV window
            ReinitializeCharObjects(characters: cells, updateText: false);
            UpdateText();
        }
        private readonly struct CharObj
        {
            public readonly char Glyph;
            public readonly Color GlyphColor;
            public readonly string Name;

            public CharObj(char glyph, Color glyphColor, string name)
            {
                Glyph = glyph;
                GlyphColor = glyphColor;
                Name = name;
            }
        }

    }
}


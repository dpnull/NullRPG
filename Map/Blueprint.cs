using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame;
using NullRPG.Extensions;

namespace NullRPG.Map
{
    public abstract class Blueprint<T> where T : MapCell, new()
    {
        public int ObjectId { get; private set; }
        public int GridSizeX { get; set; }
        public int GridSizeY { get; set; }
        public string BlueprintPath { get; private set; }

        public Blueprint()
        {
            ObjectId = BlueprintDatabase.GetUniqueId();
            InitializeBlueprint(Constants.Blueprint.BLUEPRINTS_PATH);
        }
        protected Blueprint(string customPath)
        {
            ObjectId = BlueprintDatabase.GetUniqueId();
            InitializeBlueprint(customPath);
        }

        private void InitializeBlueprint(string path)
        {
            BlueprintPath = path;
            var blueprintPath = Path.Combine(BlueprintPath, GetType().Name + ".txt");
            var blueprintConfigPath = Path.Combine(Constants.Blueprint.BLUEPRINTS_CONFIG_PATH, Constants.Blueprint.BLUEPRINT_TILES + ".json");
            var config = JsonConvert.DeserializeObject<BlueprintConfig>(File.ReadAllText(blueprintConfigPath));

            if (!File.Exists(blueprintConfigPath) || !File.Exists(blueprintPath))
                throw new Exception("Blueprint config file(s) were not found for " + Constants.Blueprint.BLUEPRINT_TILES);

            var blueprint = File.ReadAllText(blueprintPath).Replace("\r", "").Split('\n');

            GridSizeX = blueprint.Max(a => a.Length);
            GridSizeY = blueprint.Length;
        }

        public T[] GetCells()
        {
            var name = GetType().Name;
            var blueprintPath = Path.Combine(BlueprintPath, name + ".txt");
            var blueprintConfigPath = Path.Combine(Constants.Blueprint.BLUEPRINTS_CONFIG_PATH, Constants.Blueprint.BLUEPRINT_TILES + ".json");

            if (!File.Exists(blueprintPath) || !File.Exists(blueprintConfigPath) || !File.Exists(Constants.Blueprint.SPECIAL_CHARACTERS_PATH))
                return Array.Empty<T>();

            var specialConfig = JsonConvert.DeserializeObject<BlueprintConfig>(File.ReadAllText(Constants.Blueprint.SPECIAL_CHARACTERS_PATH));
            var specialChars = specialConfig.Tiles.ToDictionary(a => a.Glyph, a => a);

            var config = JsonConvert.DeserializeObject<BlueprintConfig>(File.ReadAllText(blueprintConfigPath));
            var tiles = config.Tiles.ToDictionary(a => (char?)a.Glyph, a => a);
            var nullTile = BlueprintTile.Null();

            foreach (var tile in tiles)
            {
                if (tile.Key == null) continue;
                if (specialChars.ContainsKey(tile.Key.Value))
                    throw new Exception("Glyph '" + tile.Key.Value + "': is reserved as a special character and cannot be used in " + name);
            }

            var blueprint = File.ReadAllText(blueprintPath).Replace("\r", "").Split('\n');

            var cells = new List<T>();
            for (int y = 0; y < GridSizeY; y++)
            {
                for (int x = 0; x < GridSizeX; x++)
                {
                    char? charValue;

                    if (y >= blueprint.Length || x >= blueprint[y].Length)
                    {
                        charValue = null;
                    }
                    else
                    {
                        charValue = blueprint[y][x];
                    }

                    var position = new Point(x, y);
                    BlueprintTile tile = nullTile;
                    if (charValue != null && !tiles.TryGetValue(charValue, out tile))
                        throw new Exception("Glyph '" + charValue + "' was not present in the config file for blueprint: " + name);
                    var foregroundColor = MonoGameExtensions.GetColorByString(tile.Foreground);
                    var backgroundColor = tile.Background != null ? MonoGameExtensions.GetColorByString(tile.Background) : Color.Black;
                    var cell = new T()
                    {
                        Glyph = tile.Glyph,
                        Position = position,
                        Foreground = foregroundColor,
                        Background = backgroundColor,
                        CellProperties = new MapCell.MapCellProperties
                        {
                            RegularForeground = foregroundColor,
                            RegularBackground = backgroundColor,
                            FovForeground = foregroundColor == Color.Transparent ? Color.Transparent : Color.Lerp(foregroundColor, Color.Black, .5f),
                            FovBackground = backgroundColor == Color.Transparent ? Color.Transparent : Color.Lerp(backgroundColor, Color.Black, .5f),
                            Walkable = tile.Walkable,
                            Interactable = tile.Interactable,
                            Name = tile.Name,
                            BlocksFov = tile.BlocksFov,
                        },
                    };
            
                    cells.Add(cell);
                }
            }
            return cells.ToArray();
        }

        public static class BlueprintDatabase
        {
            public static readonly Dictionary<int, Blueprint<T>> Blueprints = new Dictionary<int, Blueprint<T>>();

            private static int _currentId;
            public static int GetUniqueId()
            {
                return _currentId++;
            }

            public static void Reset()
            {
                Blueprints.Clear();
                _currentId = 0;
            }

            public static void ResetExcept(params int[] ids)
            {
                var toRemove = new List<int>();
                foreach (var entity in Blueprints)
                {
                    toRemove.Add(entity.Key);
                }

                toRemove = toRemove.Except(ids).ToList();
                foreach (var id in toRemove)
                    Blueprints.Remove(id);

                _currentId = Blueprints.Count == 0 ? 0 : (Blueprints.Max(a => a.Key) + 1);
            }
        }
    }

    [Serializable]
    internal class BlueprintConfig
    {
#pragma warning disable 0649
        public BlueprintTile[] Tiles;
#pragma warning restore 0649
    }

    [Serializable]
    internal class BlueprintTile
    {
        public char Glyph;
        public string Name;
        public bool Walkable;
        public bool Interactable;
        public string Foreground;
        public string Background;
        public bool BlocksFov;
        public bool EmitsLight;
        public string LightColor;
        public int LightRadius;
        public float Brightness;

        public static BlueprintTile Null()
        {
            var nullTile = new BlueprintTile
            {
                Glyph = ' ',
                Foreground = "BurlyWood",
                Background = "Black",
                Name = null,
                Walkable = false
            };

            return nullTile;
        }
    }
}

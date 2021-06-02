using NullRPG.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class GridManager
    {
        public static MapGrid Grid { get; private set; }
        public static Blueprint<MapCell> ActiveBlueprint { get { return Grid?.Blueprint; } }

        private static readonly Dictionary<Type, MapGrid> _blueprintGridCache = new Dictionary<Type, MapGrid>();

        public static void InitializeBlueprint<T>(bool saveGridData) where T : Blueprint<MapCell>, new()
        {
            if (!saveGridData)
            {
                Grid = new MapGrid(new T());
                return;
            }

            if(_blueprintGridCache.TryGetValue(typeof(T), out MapGrid grid))
            {
                Grid = grid;
            }
            else
            {
                Grid = new MapGrid(new T());

                _blueprintGridCache.Add(typeof(T), grid);
            }
        }
        public static void InitializeCustomGrid(MapGrid grid)
        {
            Grid = grid;
        }


    }
}

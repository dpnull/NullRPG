using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class World : IWorld
    {
        public string Name { get; set; }
        public Dictionary<int, IArea> Areas { get; set; }

        public World(string name)
        {
            Name = name;
            Areas = new Dictionary<int, IArea>();
            
        }

        private int _currentId;
        public int GetUniqueAreaId()
        {
            return _currentId++;
        }

        public void SetLevels()
        {
            var areas = WorldManager.GetWorldAreas<Area>(Name).ToArray();

            foreach(var area in areas)
            {
                var locations = WorldManager.GetWorldAreaLocations<IWorld>(area).ToArray();

                int lowestLevel = locations.ElementAt(0).MinLevel;
                int highestLevel = locations.ElementAt(0).MaxLevel;

                for (int i = 1; i < area.Locations.Count; i++)
                {
                    if (lowestLevel < area.Locations.ElementAt(i).Value.MinLevel) { lowestLevel = area.Locations.ElementAt(i).Value.MinLevel; }
                    if (highestLevel < area.Locations.ElementAt(i).Value.MaxLevel) { highestLevel = area.Locations.ElementAt(i).Value.MaxLevel; }
                }

                area.MinLevel = lowestLevel;
                area.MaxLevel = highestLevel;
            }
        }
    }
}

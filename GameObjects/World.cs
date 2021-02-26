using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public class World
    {
        public List<Location> _locations = new List<Location>();

        public void AddLocation(int x, int y, string name, string description, bool canGather = false)
        {
            Location location = new Location();

            location.X = x;
            location.Y = y;
            location.Name = name;
            location.Description = description;
            location.CanGather = canGather;

            _locations.Add(location);
        }

        public Location GetLocation(int x, int y)
        {
            foreach(Location location in _locations)
            {
                if(location.X == x && location.Y == y)
                {
                    return location;
                }
            }

            return null;
        }

        public Location[] GetLocations()
        {
            return _locations.ToArray();
        }
    }
}

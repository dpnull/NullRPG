using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.GameObjects.Abstracts;

namespace NullRPG.GameObjects
{
    public class Player : Entity
    {
        public enum PlayableClass
        {
            Warrior,
            Mage,
            Barbarian
        }
        public int Experience { get; private set; }
        public int Level { get; private set; }
        public PlayableClass CharacterClass { get; private set; }
        public Location Location { get; private set; }
        public Player(string name, int health, int maxHealth, int gold, int experience, int level, PlayableClass characterClass, Location location) : base(name, health, maxHealth, gold)
        {
            Experience = experience;
            Level = level;
            CharacterClass = characterClass;
            Location = location;
        }

        public Location GetCurrentLocation()
        {
            return Location;
        }

        public void TravelToLocation(Location loc)
        {
            Location = loc;
        }
    }
}

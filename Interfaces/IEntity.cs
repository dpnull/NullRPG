using NullRPG.GameObjects;

namespace NullRPG.Interfaces
{
    public interface IEntity
    {
        public int ObjectId { get; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int Defense { get; set; }
        public EntityInventory Inventory { get; set; }
        public World CurrentWorld { get; set; }
        public Area CurrentArea { get; set; }
        public Location CurrentLocation { get; set; }
    }
}
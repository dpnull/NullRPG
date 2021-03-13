using NullRPG.Interfaces;
using NullRPG.Managers;

namespace NullRPG.GameObjects
{
    public abstract class Entity : IEntity
    {
        private int _minDmg;
        private int _maxDmg;
        private int _defense;
        public World CurrentWorld { get; set; }
        public Area CurrentArea { get; set; }
        public Location CurrentLocation { get; set; }
        public int ObjectId { get; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Gold { get; set; }

        public int MinDmg
        {
            get
            {
                var equipped = InventoryManager.GetEquippedItems<EntityInventory>();
                int _totalMinDmg = 0;
                foreach (var item in equipped)
                {
                    _totalMinDmg += item.MinDmg;
                }
                return _minDmg + _totalMinDmg;
            }
            set
            {
                _minDmg = value;
            }
        }

        public int MaxDmg
        {
            get
            {
                var equipped = InventoryManager.GetEquippedItems<EntityInventory>();
                int _totalMaxDmg = 0;
                foreach (var item in equipped)
                {
                    _totalMaxDmg += item.MaxDmg;
                }
                return _maxDmg + _totalMaxDmg;
            }
            set
            {
                _maxDmg = value;
            }
        }

        public int Defense
        {
            get
            {
                var equipped = InventoryManager.GetEquippedItems<EntityInventory>();
                int _totalDefense = 0;
                foreach (var item in equipped)
                {
                    _totalDefense += item.Defense;
                }
                return _defense + _totalDefense;
            }
            set
            {
                _defense = value;
            }
        }

        public EntityInventory Inventory { get; set; }

        public Entity(string name, int health, int gold, int level)
        {
            ObjectId = EntityManager.GetUniqueId();
            Name = name;
            Health = health;
            Gold = gold;
            Level = level;

            MaxHealth = Health;
            MinDmg = 0;
            MaxDmg = 0;
            Defense = 0;
        }
    }
}
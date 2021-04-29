using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Inventory;
using NullRPG.GameObjects.Items;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class Player : ComponentSystemEntity, IEntity
    {
        public Player() : base("Tianyu", EntityManager.GetUniqueId())
        {
            EntityManager.Add(this);

            var stats = new EntityComponents.BaseStats();
            stats.Attack = 0;
            stats.Defense = 0;
            stats.Experience = 0;
            stats.Gold = 25;
            stats.Health = 100;
            stats.MaxHealth = stats.Health;
            stats.RequiredExperience = 250;
            stats.Level = 1;

            AddComponent(stats);

            var inventory = new EntityComponents.Inventory();
            AddComponent(inventory);

            InventoryManager.AddToInventory(this, Weapon.Longsword());

            var equipment = new EntityComponents.Equipment();
            AddComponent(equipment);

            var position = new EntityComponents.Position();

            var world = WorldManager.GetWorld<IWorld>(WorldManager.GetWorlds().FirstOrDefault().ObjectId);
            var area = AreaManager.Get<IArea>(world.Areas.Values.FirstOrDefault().ObjectId);
            var location = LocationManager.Get<ILocation>(area.Locations.Values.FirstOrDefault().ObjectId);

            AddComponent(position);

            position.World = world;
            position.Area = area;
            position.Location = location;
        }
    }
}

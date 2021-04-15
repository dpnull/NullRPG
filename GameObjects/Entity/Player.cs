using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Entity;
using NullRPG.GameObjects.Items.Armors;
using NullRPG.GameObjects.Items.Misc;
using NullRPG.GameObjects.Items;
using NullRPG.Managers;
using System.Linq;
using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Entity
{
    public class Player : BaseEntity
    {
        public Player() : base("Dom", 1)
        {
            EntityComponent entity = new EntityComponent(this);
            Components.Add(entity);
            EntityComponentValue entityValue = new EntityComponentValue(100, 2, 35);
            ReceiveComponentValue(entityValue);

            InventoryComponent inventory = new InventoryComponent(this);
            Components.Add(inventory);
            InventoryComponentValue inventoryValue = new InventoryComponentValue(new PlayerInventory());
            ReceiveComponentValue(inventoryValue);

            PositionComponent position = new PositionComponent(this);
            Components.Add(position);

            var world = WorldManager.GetWorld<IWorld>(WorldManager.GetWorlds().FirstOrDefault().ObjectId);
            var area = AreaManager.GetAreaByObjectId<IArea>(world.Areas.Values.FirstOrDefault().ObjectId);
            var location = LocationManager.GetLocationByObjectId<ILocation>(area.Locations.Values.FirstOrDefault().ObjectId);

            PositionComponentValue positionValue = new PositionComponentValue(world, area, location);
            ReceiveComponentValue(positionValue);

            InventoryManager.AddToInventory(this, Misc.Birchwood());
            InventoryManager.AddToInventory(this, Misc.Birchwood());
            InventoryManager.AddToInventory(this, Misc.Birchwood());

            InventoryManager.AddToInventory(this, Items.Armors.Helmet.IronHelmet());
            InventoryManager.AddToInventory(this, Items.Armors.Chest.IronChestplate());
            InventoryManager.AddToInventory(this, Items.Armors.Legs.IronLeggings());
            InventoryManager.AddToInventory(this, Items.Weapons.Sword.Longsword());
            InventoryManager.AddToInventory(this, Items.Weapons.Sword.Longsword());

           
        }
    }
}
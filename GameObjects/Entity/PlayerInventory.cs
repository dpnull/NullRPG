using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Managers;

namespace NullRPG.GameObjects.Entity
{
    public class PlayerInventory : EntityInventory
    {
        public PlayerInventory() : base()
        {
            InventoryManager.CreateDefault(this);

            HandsSlot = Sword.None();
            HeadSlot = Items.Armors.Helmet.None();
            ChestSlot = Items.Armors.Chest.IronChestplate();
            LegsSlot = Items.Armors.Legs.IronLeggings();
        }
    }
}
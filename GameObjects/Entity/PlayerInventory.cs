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

            WeaponSlot = Sword.Longsword();
            HeadSlot = Items.Armors.Helmet.IronHelmet();
            ChestSlot = Items.Armors.Chest.IronChestplate();
            LegsSlot
        }
    }
}
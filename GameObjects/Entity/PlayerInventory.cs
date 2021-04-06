using NullRPG.GameObjects.Abstracts;
using NullRPG.Managers;

namespace NullRPG.GameObjects.Entity
{
    public class PlayerInventory : EntityInventory
    {
        public PlayerInventory() : base()
        {
            InventoryManager.CreateDefault(this);

            WeaponSlot = new Items.Weapons.None();
            HeadSlot = new Items.Armors.Head.None();
        }
    }
}
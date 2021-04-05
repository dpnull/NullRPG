using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.GameObjects.Items.Misc;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

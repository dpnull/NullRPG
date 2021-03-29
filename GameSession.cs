using NullRPG.GameObjects.Entity;
using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{
    public class GameSession
    {
        public PlayerInventory PlayerInventory { get; set; }

        public GameSession()
        {
            Longsword longsword = new Longsword();
            IronHelmet ironHelmet = new IronHelmet();

            PlayerInventory = new PlayerInventory();
            ItemManager.CreateItems();

            PlayerInventory.WeaponSlot = longsword;
            PlayerInventory.HeadSlot = ironHelmet;
        }
    }
}

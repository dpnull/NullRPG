using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items.Weapons
{
    public class Longsword : Item
    {
        public Longsword() : base("Longsword", Enums.ItemTypes.Weapon)
        {
            WeaponAttribute longswordAttribute = new WeaponAttribute(this);
            Components.Add(longswordAttribute);
            WeaponMessage longswordMessage = new WeaponMessage(7, 10);
            ReceiveMessage(longswordMessage);
        }
    }
}

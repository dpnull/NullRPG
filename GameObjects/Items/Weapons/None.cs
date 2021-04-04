using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items.Weapons
{
    public class None : Weapon
    {
        public None() : base("None")
        {
            WeaponAttribute att = new WeaponAttribute(this);
            Components.Add(att);
            WeaponMessage msg = new WeaponMessage(0, 0);
            ReceiveMessage(msg);
            ItemSubTypeAttribute longswordSubType = new ItemSubTypeAttribute(this);
            Components.Add(longswordSubType);
            ItemSubTypeMessage longswordItemSubType = new ItemSubTypeMessage(Enums.ItemSubTypes.Sword);
            ReceiveMessage(longswordItemSubType);
        }
    }
}

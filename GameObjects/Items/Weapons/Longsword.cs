using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items.Weapons
{
    public class Longsword : Weapon
    {
        public Longsword() : base("Longsword")
        {
            Value = 10;

            WeaponComponent longswordComponent = new WeaponComponent(this);
            Components.Add(longswordComponent);
            WeaponComponentValue longswordComponentValue = new WeaponComponentValue(7, 10);
            ReceiveComponentValue(longswordComponentValue);

            ItemTypeComponent longswordSubType = new ItemTypeComponent(this);
            Components.Add(longswordSubType);
            ItemTypeComponentValue longswordItemSubType = new ItemTypeComponentValue(Enums.ItemTypes.Sword);
            ReceiveComponentValue(longswordItemSubType);
        }
    }
}

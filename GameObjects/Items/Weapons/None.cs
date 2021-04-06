using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Weapons
{
    public class None : Weapon
    {
        public None() : base("None")
        {
            WeaponComponent att = new WeaponComponent(this);
            Components.Add(att);
            WeaponComponentValue msg = new WeaponComponentValue(0, 0);
            ReceiveComponentValue(msg);
            ItemTypeComponent longswordSubType = new ItemTypeComponent(this);
            Components.Add(longswordSubType);
            ItemTypeComponentValue longswordItemSubType = new ItemTypeComponentValue(Enums.ItemTypes.Sword);
            ReceiveComponentValue(longswordItemSubType);
        }
    }
}
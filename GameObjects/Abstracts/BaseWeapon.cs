using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseWeapon : BaseItem
    {
        public Enums.ItemCategories ItemCategory { get; } = Enums.ItemCategories.Weapon;
        public BaseWeapon(string name, int minDamage, int maxDamage) : base(name, isStackable: false)
        {
            var damageComponent = new ItemComponents.Damage();
            damageComponent.ModifyDamage(minDamage, maxDamage);

            AddComponent(damageComponent);
        }
    }
}

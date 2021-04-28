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
        public BaseWeapon(string name, int minDamage, int maxDamage, int value, int level) : base(name, isStackable: false, value, level)
        {
            var damageComponent = new ItemComponents.Damage();
            damageComponent.ModifyDamage(minDamage, maxDamage);

            var equippableComponent = new ItemComponents.EquippableComponent(Enums.EquippableTypes.Hands);

            AddComponent(equippableComponent);
            AddComponent(damageComponent);
        }
    }
}

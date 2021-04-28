using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseArmor : BaseItem
    {
        public Enums.ItemCategories ItemCategory { get; } = Enums.ItemCategories.Armor;

        public BaseArmor(string name, int baseDefense, int value, int level) : base(name, isStackable: false, value, level)
        {
            var defenseComponent = new ItemComponents.Defense();
            defenseComponent.ModifyBaseDefense(baseDefense);

            AddComponent(defenseComponent);
        }
    }
}

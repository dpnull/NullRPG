using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Weapon : BaseItem
    {
        public Weapon(string name) : base(name, Enums.ItemCategories.Weapon)
        {

        }
    }
}

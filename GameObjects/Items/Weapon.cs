using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items
{
    class Weapon : BaseWeapon
    {
        public Weapon(string name, int minDamage = 0, int maxDamage = 0) : base(name, minDamage, maxDamage) { }

        public static Weapon Longsword()
        {
            return new Weapon("Longsword", 8, 12);
        }
    }
}

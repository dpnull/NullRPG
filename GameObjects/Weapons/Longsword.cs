using NullRPG.GameObjects.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Weapons
{
    public class Longsword : BaseMeleeWeapon
    {
        public WeaponType DefType => WeaponType.Sword;

        // Add Primary attack 
        // and Secondary attack

        public override string Name => "Longsword";
        public override int MinDamage => 9;
        public override int MaxDamage => 13;
        public override int Gold => 24;

    }
}

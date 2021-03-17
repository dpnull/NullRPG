using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items
{
    public abstract class BaseWeapon : Item, IWeapon
    {

        public virtual int MinDamage => 0;
        public virtual int MaxDamage => 0;
    }
}

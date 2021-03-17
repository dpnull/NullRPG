using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    interface IWeapon
    {
        int MinDamage { get; }
        int MaxDamage { get; }
    }
}

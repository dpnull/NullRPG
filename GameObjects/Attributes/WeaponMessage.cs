using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Attributes
{
    public class WeaponMessage
    {
        public int MinDamage;
        public int MaxDamage;

        public WeaponMessage(int minDamage, int maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}

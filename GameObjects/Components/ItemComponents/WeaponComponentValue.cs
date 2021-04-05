using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.ItemComponents
{
    public class WeaponComponentValue
    {
        public int MinDamage;
        public int MaxDamage;

        public WeaponComponentValue(int minDamage, int maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}

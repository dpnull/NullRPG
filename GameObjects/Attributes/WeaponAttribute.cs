using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Attributes
{
    public class WeaponAttribute : IAttribute
    {
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public IItem Source { get; set; }

        public WeaponAttribute(IItem source)
        {
            Source = source;
        }

        public void ReceiveMessage<T>(T message)
        {
            WeaponMessage weaponMessage = message as WeaponMessage;
            if (weaponMessage != null)
            {
                MinDamage = weaponMessage.MinDamage;
                MaxDamage = weaponMessage.MaxDamage;
            }
        }
    }
}

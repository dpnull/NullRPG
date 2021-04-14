using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items.Armors
{
    public class Legs : Armor
    {
        public Legs(string name, int defense, int value) : base(name, defense, Enums.EquippableTypes.Legs, value)
        {

        }

        public static Legs IronLeggings()
        {
            return new Legs("Iron Leggings", 5, 9);
        }
    }
}

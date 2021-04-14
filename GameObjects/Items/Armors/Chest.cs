using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items.Armors
{
    public class Chest : Armor
    {
        public Chest(string name, int defense, int value) : base(name, defense, Enums.EquippableTypes.Chest, value)
        {

        }

        public static Chest IronChestplate()
        {
            return new Chest("Iron Chestplate", 7, 10);
        }

        public static Chest None()
        {
            return new Chest("None", 0, 0);
        }


    }
}

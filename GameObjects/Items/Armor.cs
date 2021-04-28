using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items
{
    public class Armor : BaseArmor
    {
        public Armor(string name, int defense, int value, int level, Enums.EquippableTypes equippableType) : base(name, defense, value, level, equippableType)
        {

        }

        public static Armor IronHelmet()
        {
            return new Armor("Iron Helmet", 4, 10, 1, Enums.EquippableTypes.Head);
        }

        public static Armor IronChestplate()
        {
            return new Armor("Iron Chestplate", 8, 16, 1, Enums.EquippableTypes.Chest);
        }

        public static Armor IronLeggings()
        {
            return new Armor("Iron Leggings", 6, 13, 1, Enums.EquippableTypes.Legs);
        }
    }
}

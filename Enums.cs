using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{
    public class Enums
    {
        public enum EquippableTypes
        {
            Hands,
            Head,
            Chest,
            Legs
        }

        public enum ItemCategories
        {
            Weapon,
            Armor,
            Misc
        }

        public enum ItemProperties
        {
            Material,
        }

        public enum WeaponTypes
        {
            Sword,
            Axe
        }

        public enum PositionTypes
        {
            Location,
            Area,
            World
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class Armor : Item
    {
        public Enums.ArmorTypes ArmorType { get; set; }
        public Armor(string name, Enums.ArmorTypes armorType) : base(name, Enums.ItemCategories.Armor)
        {
            ArmorType = armorType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class Miscellaneous : Item
    {
        public Miscellaneous(string name) : base(name, Enums.ItemCategories.Misc)
        {
            IsStackable = true;
        }
    }
}

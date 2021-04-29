using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Items
{
    public class Miscellaneous : BaseMiscellaneous
    {
        public Miscellaneous(string name, int value = 0, int level = 0) : base(name, value, level)
        {

        }

        public static Miscellaneous Birchwood()
        {
            var birchwood = new Miscellaneous("Birchwood log", 5, 1);
            birchwood.AddProperty(Enums.ItemProperties.Material);
            return birchwood;
        }
    }
}

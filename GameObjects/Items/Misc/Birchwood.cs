using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.GameObjects.Items.Misc
{
    public class Birchwood : Miscellaneous
    {
        public Birchwood() : base("Birchwood")
        {
            Value = 5;
        }
    }
}

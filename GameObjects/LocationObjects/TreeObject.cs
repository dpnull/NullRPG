using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Items.Misc;

namespace NullRPG.GameObjects.LocationObjects
{
    public class TreeObject : BaseLocationObject
    {
        public TreeObject(string name) : base(name)
        {

        }

        public static TreeObject Birchwood()
        {
            var birchwood = new TreeObject("Birchwood");
            birchwood.AddItem(Misc.Birchwood());

            return birchwood;
        }
    }
}

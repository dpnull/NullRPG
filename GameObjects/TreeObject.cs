using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public class TreeObject : WorldObjectBase
    {
        public TreeObject(string name, IItem[] items, Objects objectType, ObjectActions objectActionType) : base(name, items, objectType, objectActionType)
        {

        }

        public static TreeObject Birchnut()
        {
            return new TreeObject("Birchnut", new IItem[] { MiscItem.BirchnutRawLog() }, Objects.Tree, ObjectActions.Chop);
        }
    }
}

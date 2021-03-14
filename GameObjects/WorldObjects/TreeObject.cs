using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.WorldObjects
{
    public class TreeObject : WorldObjectBase
    {
        public TreeObject(string name, List<IItem> items, Objects objectType, ObjectActions objectActionType) : base(name, items, objectType, objectActionType)
        {

        }

        public static TreeObject Birchnut()
        {
            return new TreeObject("Birchnut", new List<IItem> { MiscItem.BirchnutRawLog() }, Objects.Tree, ObjectActions.Chop);
        }
    }
}

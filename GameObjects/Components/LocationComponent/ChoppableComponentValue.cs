using NullRPG.GameObjects.LocationObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Components.LocationComponent
{
    public class ChoppableComponentValue
    {
        public TreeObject TreeObject;

        public ChoppableComponentValue(TreeObject treeObject)
        {
            TreeObject = treeObject;
        }


    }
}

using Microsoft.Xna.Framework.Input;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Input
{
    public class IndexedKeybinding : IIndexedKeybinding
    {
        public int ObjectId { get; set; }
        public int Index { get; set; }
        public Keys Key { get; set; }

        public IndexedKeybinding(int index, Keys key, int indexableObjectId)
        {
            Index = index;
            ObjectId = indexableObjectId;
            Key = key;
        }
    }
}

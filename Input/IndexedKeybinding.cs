using Microsoft.Xna.Framework.Input;
using NullRPG.Interfaces;

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
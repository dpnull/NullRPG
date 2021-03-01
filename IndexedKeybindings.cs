using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;

namespace NullRPG
{
    public class IndexedKeybindings
    {
        public Dictionary<int, Microsoft.Xna.Framework.Input.Keys> IndexedKeybindingsDictionary = new Dictionary<int, Microsoft.Xna.Framework.Input.Keys>();

        public List<IndexedInventoryKeybinding> _indexedInventoryKeybindings = new List<IndexedInventoryKeybinding>();

        public IndexedKeybindings(Item[] items)
        {
            InitializeIndexedKeybindingsDictionary();
            InitializeIndexedInventoryKeybindings(items);
        }

        // Add indexed keybindings objects to the dictionary. Objects use an int as key necessary for fetching value by using the passed index.
        public void InitializeIndexedKeybindingsDictionary()
        {
            (int, Microsoft.Xna.Framework.Input.Keys)[] indexedKeybindings = new (int, Microsoft.Xna.Framework.Input.Keys)[]
            {
                (0, Microsoft.Xna.Framework.Input.Keys.D1),
                (1, Microsoft.Xna.Framework.Input.Keys.D2),
                (2, Microsoft.Xna.Framework.Input.Keys.D3),
                (3, Microsoft.Xna.Framework.Input.Keys.D4),
                (4, Microsoft.Xna.Framework.Input.Keys.D5),
                (5, Microsoft.Xna.Framework.Input.Keys.D6),
                (6, Microsoft.Xna.Framework.Input.Keys.D7),
                (7, Microsoft.Xna.Framework.Input.Keys.D8),
                (8, Microsoft.Xna.Framework.Input.Keys.D9),
                (9, Microsoft.Xna.Framework.Input.Keys.D0),
            };

            foreach (var indexedKeybinding in indexedKeybindings)
            {
                IndexedKeybindingsDictionary.Add(indexedKeybinding.Item1, indexedKeybinding.Item2);
            }
        }

        // Initialize keybinding objects for inventory by using the passed items array.
        private void InitializeIndexedInventoryKeybindings(Item[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                _indexedInventoryKeybindings.Add(IndexedInventoryKeybinding.AddIndexedKeybinding(i, GetIndexedKeybinding(i), items[i]));
            }
        }

        // Returns a XNA key from the dictionary based on the passed key.
        public Microsoft.Xna.Framework.Input.Keys GetIndexedKeybinding(int index)
        {
            if (IndexedKeybindingsDictionary.TryGetValue(index, out Microsoft.Xna.Framework.Input.Keys value)) return value;
            throw new System.Exception($"No keybinding defined with index: {index}");
        }


        // Return a XNA keybinding from the travel object based on the passed index
        public Microsoft.Xna.Framework.Input.Keys GetInventoryKeybinding(int index)
        {
            foreach (var item in _indexedInventoryKeybindings)
            {
                if (index == item.Index)
                {
                    return item.Keybinding;
                }
            }

            // Temporary hack for return
            return Microsoft.Xna.Framework.Input.Keys.F20;
        }

        public Item GetIndexedItem(int index)
        {
            foreach (var item in _indexedInventoryKeybindings)
            {
                if (index == item.Index)
                {
                    return item.Item;
                }
            }
            return null;
        }


        public bool IsNotNull(int index)
        {
            foreach (var keybinding in _indexedTravelKeybindings)
            {
                if (index == keybinding.Index)
                {
                    if (keybinding == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public class IndexedKeybinding : IIndexable
    {
        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                _index += 1;
            }
        }
        public Microsoft.Xna.Framework.Input.Keys Keybinding { get; set; }
        public object Object { get; set; }

        public static IndexedKeybinding AddIndexedKeybinding(int index, Microsoft.Xna.Framework.Input.Keys keybinding, Item item)
        {
            IndexedKeybinding indexKeybinding = new IndexedKeybinding();

            indexKeybinding.Index = index;
            indexKeybinding.Keybinding = keybinding;
            indexKeybinding.Object = item;

            return indexKeybinding;
        }
    }
}

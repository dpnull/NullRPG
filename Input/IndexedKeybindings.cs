using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System.Linq;

namespace NullRPG.Input
{

    public class IndexedKeybindings
    {
        public Dictionary<int, Microsoft.Xna.Framework.Input.Keys> IndexedKeybindingsDictionary = new Dictionary<int, Microsoft.Xna.Framework.Input.Keys>();

        public List<IIndexedKeybinding> _indexedKeybindings = new List<IIndexedKeybinding>();

        public IndexedKeybindings(IIndexable[] indexable)
        {
            InitializeIndexedKeybindingsDictionary();
            Initialize(indexable);
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


        // New Dictionary of index ints and Keys
        // where index corresponds to D keys
        // then use the dictionary to initialize objects starting from i = 0 where passed object is assigned to the index for later reference
        // It is done by assigning key from dictionary based on the i

        private void Initialize(IIndexable[] indexableArr)
        {
            int index = 0;
            foreach(var item in indexableArr)
            {
                var indexable = item;
                AddIndexedKeybinding<IndexedInventoryKeybinding>(index, GetIndexedKeybinding(index), indexable); // temporary solution for i
                index++;        
            }
        }

        public void AddIndexedKeybinding<T>(int index, Microsoft.Xna.Framework.Input.Keys keybinding, IIndexable indexable) where T : IIndexedKeybinding, new()
        {
            T obj = new T
            {
                Index = index,
                Keybinding = keybinding,
                Object = indexable
            };

            _indexedKeybindings.Add(obj);
        }

        // Returns a XNA key from the dictionary based on the passed key.
        public Microsoft.Xna.Framework.Input.Keys GetIndexedKeybinding(int index)
        {
            if (IndexedKeybindingsDictionary.TryGetValue(index, out Microsoft.Xna.Framework.Input.Keys value)) return value;
            throw new System.Exception($"No keybinding defined with index: {index}");
        }

        public IIndexable GetIndexable(int index)
        {
            if(index < _indexedKeybindings.Count)
                if(_indexedKeybindings[index] != null)
                    return _indexedKeybindings[index].Object;
            throw new System.Exception($"No indexed keybinding exists at index_{index}.");
        }

        public IIndexedKeybinding[] GetIndexedKeybindings()
        {
            return _indexedKeybindings.ToArray();
        }

        /*
        public object GetIndexedItem(int index)
        {
            foreach (var slot in _indexedKeybindings)
            {
                if (index == slot.Object)
                {
                    return slot.Object
                }
            }
            return null;
        }
        */

        // TO REVISE
        public bool IsNotNull(int index)
        {
            foreach (var keybinding in _indexedKeybindings)
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
    public class IndexedInventoryKeybinding : IIndexedKeybinding
    {
        public int Index { get; set; }

        // redundant?
        public int IncrementIndex()
        {
            return Index++;
        }
        public Microsoft.Xna.Framework.Input.Keys Keybinding { get; set; }
        public IIndexable Object { get; set; }
    }
}

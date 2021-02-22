using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG
{
    public class IndexedKeybindings
    {
        public Dictionary<int, Microsoft.Xna.Framework.Input.Keys> IndexedKeybindingsDictionary = new Dictionary<int, Microsoft.Xna.Framework.Input.Keys>();

        public List<IndexedTravelKeybinding> _indexedTravelKeybindings = new List<IndexedTravelKeybinding>();

        public IndexedKeybindings(World world)
        {
            InitializeIndexedKeybindingsDictionary();
            InitializeIndexedKeybindings(world);
        }

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

        private void InitializeIndexedKeybindings(World world)
        {
            for (int i = 0; i < world.GetLocations().Length; i++)
            {
                _indexedTravelKeybindings.Add(IndexedTravelKeybinding.AddIndexedKeybinding(i, GetIndexedKeybinding(i), world.GetLocations()[i]));
            }
        }

        public Microsoft.Xna.Framework.Input.Keys GetIndexedKeybinding(int index)
        {
            if (IndexedKeybindingsDictionary.TryGetValue(index, out Microsoft.Xna.Framework.Input.Keys value)) return value;
            throw new System.Exception($"No keybinding defined with index: {index}");
        }

        public Microsoft.Xna.Framework.Input.Keys GetTravelKeybinding(int index)
        {
            foreach (var keybinding in _indexedTravelKeybindings)
            {
                if (index == keybinding.Index)
                {
                    return keybinding.Keybinding;
                }
            }

            return Microsoft.Xna.Framework.Input.Keys.Z;
        }

        public Location GetIndexedLocation(int index)
        {
            foreach (var keybinding in _indexedTravelKeybindings)
            {
                if (index == keybinding.Index)
                {
                    return keybinding.Location;
                }
            }
            return null;
        }

        public bool IsNotNull(int index)
        {
            foreach(var keybinding in _indexedTravelKeybindings)
            {
                if(index == keybinding.Index)
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

    public class IndexedTravelKeybinding
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
        public Location Location { get; set; }

        public static IndexedTravelKeybinding AddIndexedKeybinding(int index, Microsoft.Xna.Framework.Input.Keys keybinding, Location location)
        {
            IndexedTravelKeybinding indexKeybinding = new IndexedTravelKeybinding();

            indexKeybinding.Index = index;
            indexKeybinding.Keybinding = keybinding;
            indexKeybinding.Location = location;

            return indexKeybinding;
        }

    }
}

using Microsoft.Xna.Framework.Input;
using NullRPG.Input;
using NullRPG.Interfaces;
using System.Collections.Generic;

namespace NullRPG.Managers
{
    public static class IndexedKeybindingsManager
    {
        private static readonly Dictionary<int, Keys> IndexedKeybindingKeys = new Dictionary<int, Keys>();

        public static bool IsInitialized { get; set; }

        public static void Initialize()
        {
            IsInitialized = false;

            InitializeIndexedKeybindingsKeys();

            IsInitialized = true;
        }

        /// <summary>
        /// Create a temporary array, assign XNA keys to integers 0 - 9 with corresponding numeric keybindings
        /// and populate IndexedKeybindingsKeys dictionary.
        /// </summary>
        private static void InitializeIndexedKeybindingsKeys()
        {
            (int, Microsoft.Xna.Framework.Input.Keys)[] _indexedKeybindingKeys = new (int, Microsoft.Xna.Framework.Input.Keys)[]
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

            foreach (var indexedKeybinding in _indexedKeybindingKeys)
            {
                IndexedKeybindingKeys.Add(indexedKeybinding.Item1, indexedKeybinding.Item2);
            }
        }

        /// <summary>
        /// Gets a XNA key from dictionary where the IndexedKeybindingKey dictionary key
        /// is equal to the passed index.
        /// </summary>
        /// <param name="index">An index integer corresponding to the desired numeric key.</param>
        /// <returns>A XNA key.</returns>
        private static Keys GetIndexedKeybindingKey(int index)
        {
            if (IndexedKeybindingKeys.TryGetValue(index, out Microsoft.Xna.Framework.Input.Keys value)) return value;
            throw new System.Exception($"No keybinding defined with index: {index}");
        }

        /// <summary>
        /// Creates and returns an array of indexed keybindings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="indexableArr"></param>
        /// <returns></returns>
        public static IIndexedKeybinding[] CreateIndexedKeybindings<T>(List<IIndexable> indexableArr) where T : IIndexedKeybinding
        {
            var collection = new IndexedKeybindings(indexableArr.ToArray());

            return collection._indexedKeybindings.ToArray();
        }

        // Helper class for creating an array of indexed keybindings.
        private class IndexedKeybindings
        {
            // add automatic indexer?
            public List<IIndexedKeybinding> _indexedKeybindings = new List<IIndexedKeybinding>();

            public IndexedKeybindings(IIndexable[] indexableArr)
            {
                int index = 0;
                foreach (var item in indexableArr)
                {
                    var indexable = item;
                    AddIndexedKeybinding<IIndexedKeybinding>(index, indexable.ObjectId);
                    index++;
                }
            }

            public void AddIndexedKeybinding<T>(int index, int indexableObjectId) where T : IIndexedKeybinding
            {
                IndexedKeybinding indexedKeybinding = new IndexedKeybinding(index, GetIndexedKeybindingKey(index), indexableObjectId);

                _indexedKeybindings.Add(indexedKeybinding);
            }
        }
    }
}
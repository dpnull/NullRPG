using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace NullRPG.Managers
{

    public enum Keybindings
    {
        Travel,
        Cancel
    }

    class KeybindingsManager
    {
        private static readonly Dictionary<Keybindings, Keys> _keybindings = new Dictionary<Keybindings, Keys>();

        public static void InitializeKeybindings()
        {
            (Keybindings, Keys)[] bindings = new (Keybindings, Keys)[]
            {
                (Keybindings.Travel, Keys.T),
                (Keybindings.Cancel, Keys.Q)
            };

            foreach(var binding in bindings)
            {
                _keybindings.Add(binding.Item1, binding.Item2);
            }
        }

        public static Keys GetKeybinding(Keybindings binding)
        {
            if (_keybindings.TryGetValue(binding, out Keys value)) return value;
            throw new System.Exception($"No keybinding defined with name: {binding}");
        }

        public static KeyValuePair<Keybindings, Keys>[] GetKeybindings()
        {
            return _keybindings.ToArray();
        }
    }
}

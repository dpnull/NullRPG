using Microsoft.Xna.Framework.Input;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using static NullRPG.Input.Keybinding;

namespace NullRPG.Managers
{
    public static class KeybindingManager
    {
        private static readonly List<IKeybinding> _keybindings = new List<IKeybinding>();

        public static bool IsInitialized { get; set; }

        public static void Initialize()
        {
            IsInitialized = false;

            CreateKeybinding(Keybindings.Travel, Category.General, Keys.T);
            CreateKeybinding(Keybindings.Inventory, Category.General, Keys.I);
            CreateKeybinding(Keybindings.Character, Category.General, Keys.C);

            CreateKeybinding(Keybindings.Equip, Category.General, Keys.E);

            CreateKeybinding(Keybindings.Back, Category.General, Keys.B);

            CreateKeybinding(Keybindings.Chop, Category.General, Keys.H);
        }

        public static void UpdateKeybindings()
        {
            /*

             TODO:
             Keybindings should be assignable to windows and then iterate through assigned keybindings to the windows to update visibility and accessbility.

             */
            UpdateVisibility(Keybindings.Travel, UserInterfaceManager.Get<GameWindow>().IsFocused);
            UpdateVisibility(Keybindings.Inventory, UserInterfaceManager.Get<GameWindow>().IsFocused);
            UpdateVisibility(Keybindings.Character, UserInterfaceManager.Get<GameWindow>().IsFocused);

            UpdateVisibility(Keybindings.Back,
                UserInterfaceManager.Get<CharacterWindow>().IsVisible ||
                UserInterfaceManager.Get<TravelWindow>().IsVisible || 
                UserInterfaceManager.Get<InventoryWindow>().IsVisible ||
                UserInterfaceManager.Get<ChoppingWindow>().IsVisible);
        }

        private static void UpdateVisibility(Keybindings keybinding, IUserInterface window)
        {
            var _keybinding = Get<IKeybinding>(keybinding);

            _keybinding.IsVisible = window.Console.IsVisible;
        }

        public static void UpdateVisibility(Keybindings keybinding, bool condition)
        {
            var _keybinding = Get<IKeybinding>(keybinding);

            _keybinding.IsVisible = condition;
        }

        public static T[] GetCategoryKeybindings<T>(Category category) where T : IKeybinding
        {
            var collection = _keybindings.Where(k => k.CategoryType == category && k.IsVisible == true).ToArray().OfType<T>();

            return collection.ToArray();
        }

        public static void Add<T>(T keybinding) where T : IKeybinding
        {
            _keybindings.Add(keybinding);
        }

        public static T Get<T>(Keybindings keybinding) where T : IKeybinding
        {
            foreach (var _keybinding in _keybindings)
            {
                if (_keybinding.Name == keybinding)
                {
                    return (T)_keybinding;
                }
            }

            return default;
        }

        public static Keys GetKeybinding<T>(Keybindings keybinding) where T : IKeybinding
        {
            var _keybinding = Get<T>(keybinding);

            if (_keybinding.IsVisible)
            {
                return _keybinding.Key;
            }
            else
                return default;
        }

        public static string GetName<T>(Keybindings keybinding) where T : IKeybinding
        {
            return Get<T>(keybinding).Name.ToString();
        }

        // Returns a string for the XNA key enum after deleting letters. Used for retrieving only the number from numerical keys.
        public static string GetKeyNameNumeric<T>(Keybindings keybinding) where T : IKeybinding
        {
            var _keybinding = Get<T>(keybinding);

            string str = String.Empty;
            for (int i = 0; i < _keybinding.Key.ToString().Length; i++)
            {
                if (Char.IsDigit(_keybinding.Key.ToString()[i]))
                {
                    str += _keybinding.Key.ToString()[i];
                }
            }

            return str;
        }

        // TEMPORARY **************
        public static string GetKeyNameNumeric(Keys key)
        {
            string str = String.Empty;
            for (int i = 0; i < key.ToString().Length; i++)
            {
                if (Char.IsDigit(key.ToString()[i]))
                {
                    str += key.ToString()[i];
                }
            }

            return str;
        }

        private static void CreateKeybinding(Keybindings name, Category category, Keys key)
        {
            Keybinding keybinding = new Keybinding(name, category, key);
            _keybindings.Add(keybinding);
        }
    }
}
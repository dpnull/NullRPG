using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NullRPG.Managers;
using System.Collections.Generic;
using System.Linq;
using NullRPG.Windows;
using System.ComponentModel;
using System;


namespace NullRPG
{
    public class Keybindings
    {
        public static List<Keybindings> _keybindings;

        public enum Type
        {
            Travel,
            Character,
            Inventory,
            View,
            All,
            Equip,
            Drop,
            Equipment,
            Miscellaneous,
            Cancel
        }

        public Type TypeName { get; set; }
        public Keys Key { get; set; }
        public bool IsVisible { get; set; }


        public void CreateKeybindings()
        {
            _keybindings = new List<Keybindings>();

            // Game Window
            AddKeybinding(Type.Character, Keys.C, false);
            AddKeybinding(Type.Inventory, Keys.I, false);

            // Temporary hack for multiple keybinding choice display
            AddKeybinding(Type.View, Keys.F20, false);

            // Cancel button
            AddKeybinding(Type.Cancel, Keys.C, false);

        }

        /// <summary>
        /// Add a new keybinding object to the keybindings list.
        /// </summary>
        /// <param name="typeName">Binding name (type).</param>
        /// <param name="key">XNA key.</param>
        /// <param name="isVisible">Visible upon creation.</param>
        public void AddKeybinding(Type typeName, Keys key, bool isVisible)
        {
            Keybindings keybinding = new Keybindings();
            keybinding.TypeName = typeName;
            keybinding.Key = key;
            keybinding.IsVisible = isVisible;

            _keybindings.Add(keybinding);
        }

        // Checks and updates visibilty of listed keybindings inside the function based on the visibilty of the console passed through the manager.
        // Can become redundant if replaced with event listeners for visibility.
        public void UpdateKeybindings()
        {

            // Game Window
            UpdateVisibility(Type.Character, UserInterfaceManager.Get<Windows.GameWindow>());
            UpdateVisibility(Type.Inventory, UserInterfaceManager.Get<Windows.GameWindow>());

            // Cancel button
            UpdateVisibility(Type.Cancel, UserInterfaceManager.Get<CharacterWindow>().IsVisible);

            /*
            // Inventory display is currently displayed externally
            UpdateVisibility(Type.All, UserInterfaceManager.Get<InventoryWindow>());
            UpdateVisibility(Type.Equipment, UserInterfaceManager.Get<InventoryWindow>());
            UpdateVisibility(Type.Miscellaneous, UserInterfaceManager.Get<InventoryWindow>());
            */
        }

        /// <summary>
        /// Show keybinding based on the visibilty of the window.
        /// </summary>
        /// <param name="typeName">Binding name (type).</param>
        /// <param name="window">Console to be checked.</param>
        private void UpdateVisibility(Type typeName, SadConsole.Console window)
        {
            if (window.IsFocused)
            {
                GetKeybindingObject(typeName).IsVisible = true;
            }
            else
            {
                GetKeybindingObject(typeName).IsVisible = false;
            }
        }

        
        // Allows for passing multiple windows visibilites.
        private void UpdateVisibility(Type typeName, bool visibility)
        {
            foreach (Keybindings binding in _keybindings)
            {
                if (typeName == binding.TypeName)
                {
                    if (visibility == false)
                    {
                        binding.IsVisible = false;
                    }
                    else
                    {
                        binding.IsVisible = true;
                    }
                }
            }
        }
        
        /// <summary>
        /// Retrieve a keybinding object using passed type name.
        /// </summary>
        /// <param name="typeName">Binding name (type).</param>
        /// <returns></returns>
        public static Keybindings GetKeybindingObject(Type typeName)
        {
            foreach (var keybinding in _keybindings)
            {
                if (keybinding.TypeName == typeName)
                {
                    return keybinding;
                }
            }

            throw new System.Exception($"Keybinding with type name {typeName} does not exit.");
        }

        /// <summary>
        /// Retrieve a keybinding XNA key using passed type name.
        /// </summary>
        /// <param name="typeName">Binding name (type).</param>
        /// <returns></returns>
        public static Keys GetKeybinding(Type typeName)
        {
            foreach (var keybinding in _keybindings)
            {
                if (keybinding.TypeName == typeName)
                {
                    return keybinding.Key;
                }
            }

            throw new System.Exception($"Keybinding with type name {typeName} does not exit.");
        }

        public static string GetKeybindingName(Type typeName)
        {
            foreach (var keybinding in _keybindings)
            {
                if (keybinding.TypeName == typeName)
                {
                    return keybinding.TypeName.ToString();
                }
            }

            throw new System.Exception($"Keybinding with type name {typeName} does not exit.");

        }

        public static string GetNumericKeyName(Keys key)
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

        /// <summary>
        /// Return a copy a of keybindings list
        /// </summary>
        /// <returns></returns>
        public List<Keybindings> GetKeybindings()
        {
            return _keybindings;
        }

        /// <summary>
        /// Retrieve a keybinding char using passed type name.
        /// </summary>
        /// <param name="typeName">Binding name (type).</param>
        /// <returns></returns>
        public static string GetKeybindingChar(Type typeName)
        {
            foreach (var keybinding in _keybindings)
            {
                if (keybinding.TypeName == typeName)
                {
                    return keybinding.Key.ToString();
                }
            }

            return "\0";
        }


    }
}

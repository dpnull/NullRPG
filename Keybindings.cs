using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NullRPG.Factories;
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
            Cancel
        }

        public Type TypeName { get; set; }
        public Keys Key { get; set; }
        public bool IsVisible { get; set; }
        

        public void CreateKeybindings()
        {
            _keybindings = new List<Keybindings>();

            // Game Window
            AddKeybinding(Type.Travel, Microsoft.Xna.Framework.Input.Keys.T, false);
            AddKeybinding(Type.Character, Keys.C, false);
            AddKeybinding(Type.Inventory, Keys.I, false);

            // Character Window
            AddKeybinding(Type.View, Keys.V, false);

            AddKeybinding(Type.Cancel, Microsoft.Xna.Framework.Input.Keys.C, false);

        }

        public void AddKeybinding(Type typeName, Keys key, bool isVisible)
        {
            Keybindings keybinding = new Keybindings();
            keybinding.TypeName = typeName;
            keybinding.Key = key;
            keybinding.IsVisible = isVisible;

            _keybindings.Add(keybinding);
        }

        public void UpdateKeybindings()
        {
            // Game window
            UpdateVisibility(Type.Travel, UserInterfaceManager.Get<Windows.GameWindow>());
            UpdateVisibility(Type.Character, UserInterfaceManager.Get<Windows.GameWindow>());
            UpdateVisibility(Type.Inventory, UserInterfaceManager.Get<Windows.GameWindow>());

            // Cancel display
            UpdateVisibility(Type.Cancel, UserInterfaceManager.Get<TravelWindow>().IsFocused ||
                                          UserInterfaceManager.Get<CharacterWindow>().IsFocused);
 
        }

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

        private void UpdateVisibility(Type typeName, bool visibility)
        {
            foreach(Keybindings binding in _keybindings)
            {
                if(typeName == binding.TypeName)
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

        public static Keys GetKeybinding(Type typeName)
        {
            foreach(var keybinding in _keybindings)
            {
                if(keybinding.TypeName == typeName)
                {
                    return keybinding.Key;
                }
            }

            throw new System.Exception($"Keybinding with type name {typeName} does not exit.");
        }

        public List<Keybindings> GetKeybindings()
        {
            return _keybindings;
        }

        public static char GetKeybindingChar(Type typeName)
        {
            foreach(var keybinding in _keybindings)
            {
                if(keybinding.TypeName == typeName)
                {
                    return char.Parse(keybinding.Key.ToString());
                }
            }

            return '\0';
        }


    }
}

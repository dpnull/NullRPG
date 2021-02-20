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
            Cancel
        }

        public Type TypeName { get; set; }
        public Keys Key { get; set; }
        public bool IsVisible { get; set; }
        

        public void CreateKeybindings()
        {
            _keybindings = new List<Keybindings>();

            // Game Window
            AddKeybinding(Keybindings.Type.Travel, Microsoft.Xna.Framework.Input.Keys.T, false);

            // Travel Window
            AddKeybinding(Keybindings.Type.Cancel, Microsoft.Xna.Framework.Input.Keys.C, false);

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
            UpdateVisibility(Type.Travel, UserInterfaceManager.Get<Windows.TravelWindow>(), true);
            UpdateVisibility(Type.Cancel, UserInterfaceManager.Get<TravelWindow>(), false);
        }

        private void UpdateVisibility(Type typeName, SadConsole.Console window, bool mustBeFalse)
        {
            if (mustBeFalse)
            {
                if (!window.IsVisible)
                {
                    GetKeybindingObject(typeName).IsVisible = true;
                }
                else
                {
                    GetKeybindingObject(typeName).IsVisible = false;
                }
            }
            else if (!mustBeFalse)
            {
                GetKeybindingObject(typeName).IsVisible = window.IsVisible;
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


    }
}

using Microsoft.Xna.Framework.Input;
using NullRPG.Interfaces;

namespace NullRPG.Input
{
    public class Keybinding : IKeybinding
    {
        public enum Keybindings
        {
            Travel,
            Inventory,
            Character,
            Back,
            Equip,
            Chop,
        }

        public enum Category
        {
            General,
            Action
        }

        public Keybindings Name { get; set; }
        public Category CategoryType { get; set; }
        public Keys Key { get; set; }
        public bool IsVisible { get; set; }

        public Keybinding(Keybindings name, Category category, Keys key)
        {
            Name = name;
            CategoryType = category;
            Key = key;
            IsVisible = false;
        }
    }
}
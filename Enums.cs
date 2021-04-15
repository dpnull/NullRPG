using System.ComponentModel;

namespace NullRPG
{
    public static class Enums
    {
        // perhaps replace with EquippableTypes instead?
        public enum InventorySlotTypes
        {
            Hands,
            Head,
            Chest,
            Legs
        }

        public enum ItemTypes
        {
            // Equippable redundant here?
            [Description("[Equippable]")]
            Equippable,
            [Description("[Material]")]
            Material,
            [Description("[Misc]")]
            Misc,
        }

        public enum EquippableTypes
        {
            Head,
            Chest,
            Legs,
            Hands
        }

        public enum ItemProperties
        {
            // Should be removed and checked via EquippableTypeComponent instead?
            Equippable,
            // Same as above once EnchantableComponent is created?
            Enchantable,
        }
        /*
         * 
         * 
         */

        // Uncertain whether this is necessary and can be replaced with something else
        public enum ItemCategories
        {
            [Description("[Weapon]")]
            Weapon,
            [Description("[Armor]")]
            Armor,
            [Description("[Misc]")]
            Misc
        }

        public enum WeaponType
        {
            Default,
            Sword,
            Axe
        }
    }
}
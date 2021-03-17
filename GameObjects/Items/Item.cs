using NullRPG.Interfaces;
using NullRPG.Managers;
using System.ComponentModel;

namespace NullRPG.GameObjects
{
    public abstract class Item : IItem, IIndexable
    {

        public int ObjectId { get; set; }
        public virtual string Name => "\0";
        public virtual int Level => 0;
        public virtual int Gold => 0;
        public bool IsUnique => false;
        public bool IsEquippable => false;

        public Item()
        {
            ObjectId = ItemManager.GetUniqueId();
            ItemManager.Add(this);
        }

        public enum Enchantments
        {
            Default,
            Fire,
            Steel
        }

        public enum WeaponType
        {
            Sword,
            Axe
        }

        public enum Rarities
        {
            [Description("Common")]
            Common,

            [Description("Uncommon")]
            Uncommon,

            [Description("Rare")]
            Rare,

            [Description("Ultra Rare")]
            VeryRare,

            [Description("Legendary")]
            Legendary
        }
    }
}
using NullRPG.GameObjects.Abstracts;
using NullRPG.GameObjects.Inventory;
using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{
    public class ItemComponents
    {
        public class PropertyComponent : IComponent
        {
            public List<Enums.ItemProperties> Properties { get; private set; } = new List<Enums.ItemProperties>();

            public void AddProperty(Enums.ItemProperties property)
            {
                if (!Properties.Contains(property))
                {
                    Properties.Add(property);
                }
            }
        }

        public class EquippableComponent : IComponent
        {
            public Enums.EquippableTypes EquippableType { get; private set; }

            public EquippableComponent(Enums.EquippableTypes equippableType)
            {
                EquippableType = equippableType;
            }

            public bool IsEquippableType(Enums.EquippableTypes equippableType)
            {
                return true ? EquippableType == equippableType : false;
            }
        }

        public class ItemType : IComponent
        {

        }

        public class Damage : IComponent
        {
            public int MinDamage { get; private set; } = 0;
            public int MaxDamage { get; private set; } = 0;

            public void ModifyDamage(int minDmg, int maxDmg)
            {
                if (minDmg < 0 || minDmg > maxDmg)
                {
                    throw new SystemException($"{nameof(minDmg)} must be greater or equal to 0 and not exceed the value of {nameof(maxDmg)}.");
                } else if (maxDmg < 0 || maxDmg < minDmg)
                {
                    throw new SystemException($"{nameof(maxDmg)} must be greater or equal to 0 and not be lower than the value of {nameof(minDmg)}.");
                } else
                {
                    MinDamage = minDmg;
                    MaxDamage = maxDmg;
                }
            }
        }

        public class Defense : IComponent
        {
            public int BaseDefense { get; private set; } = 0;

            public void ModifyBaseDefense(int baseDefense)
            {
                BaseDefense = baseDefense;
            }
        }

        public class Value : IComponent
        {
            public int BaseValue { get; set; }
        }
    }

    public class EntityComponents
    {
        public class Inventory : IComponent
        {
            public EntityInventory EntityInventory { get; private set; }

            public Inventory(IEntityInventory inventory)
            {
                EntityInventory = (EntityInventory)inventory;
            }
        }

        public class Equipment : IComponent
        {
            // will be expanded once user is able to add and delete custom equipment slots

            private List<EquipmentSlot> EquipmentSlots;

            public Equipment()
            {
                CreateDefaultEquipmentSlots();
            }

            private void CreateDefaultEquipmentSlots()
            {
                EquipmentSlots = new List<EquipmentSlot>();
                AddNewEquipmentSlot(Enums.EquippableTypes.Hands);
                AddNewEquipmentSlot(Enums.EquippableTypes.Head);
                AddNewEquipmentSlot(Enums.EquippableTypes.Chest);
                AddNewEquipmentSlot(Enums.EquippableTypes.Legs);
            }

            public void AddNewEquipmentSlot(Enums.EquippableTypes equippableType)
            {
                if(!EquipmentSlots.All(e => e.EquippableType == equippableType)) {
                    EquipmentSlots.Add(new EquipmentSlot(equippableType));
                }
            }

            public List<IItem> GetEquippedSlotItems()
            {
                List<IItem> items = new List<IItem>();
                foreach(var item in EquipmentSlots)
                {
                    items.Add(item.Item);
                }

                return items;
            }

            public void EquipItem(IItem item)
            {
                if (item.HasComponent<ItemComponents.EquippableComponent>())
                {
                    var collection = EquipmentSlots.ToArray();
                    foreach (var i in collection)
                    {
                        if(item.GetComponent<ItemComponents.EquippableComponent>().EquippableType == i.EquippableType)
                        {
                            i.Item = item;
                        }
                    }
                }

            }

            public class EquipmentSlot : IComponent
            {
                /// <summary>
                /// Stores equippable item. the assigned equippable type for an item must match the stored type.
                /// </summary>
                public IItem Item { get; set; }
                public readonly Enums.EquippableTypes EquippableType;

                public EquipmentSlot(Enums.EquippableTypes equippableType)
                {
                    EquippableType = equippableType;
                }
            }

        }

        public class BaseStats : IComponent
        {
            public int Health { get; set; }
            public int MaxHealth { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Gold { get; set; }
            public int Level { get; set; }
            public int Experience { get; set; }
            public int RequiredExperience { get; set; }
        }

        public class Position : IComponent
        {
            public ILocation Location { get; set; }
            public IArea Area { get; set; }
            public IWorld World { get; set; }
        }
    }

    public class LocationObjectComponents
    {
     
    }

}

using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public abstract class BaseItem : ComponentSystemEntity, IItem
    {
        public bool IsStackable { get; }
        public BaseItem(string name, bool isStackable, int value, int level) : base(name, ItemManager.GetUniqueId())
        {
            ItemManager.Add(this);
            IsStackable = isStackable;

            var baseComponent = new ItemComponents.BaseItemComponent();
            baseComponent.ItemLevel = level;
            baseComponent.Value = value;

            AddComponent(baseComponent);
        }
    }
}   

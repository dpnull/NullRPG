using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Armors.Head
{
    public class None : Armor
    {
        public None() : base("None", Enums.ArmorTypes.Head)
        {
            ArmorComponent ironHelmetComponent = new ArmorComponent(this);
            Components.Add(ironHelmetComponent);
            ArmorComponentValue ironHelmetComponentValue = new ArmorComponentValue(0);
            ReceiveComponentValue(ironHelmetComponentValue);
            ItemTypeComponent longswordSubType = new ItemTypeComponent(this);
            Components.Add(longswordSubType);
            ItemTypeComponentValue longswordItemSubType = new ItemTypeComponentValue(Enums.ItemTypes.HeadArmor);
            ReceiveComponentValue(longswordItemSubType);
            
        }
    }
}

using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Components.Item;

namespace NullRPG.GameObjects.Items.Armors.Head
{
    public class IronHelmet : Armor
    {
        public IronHelmet() : base("Iron Helmet", Enums.ArmorTypes.Head)
        {
            Value = 10;

            ArmorComponent ironHelmetComponent = new ArmorComponent(this);
            Components.Add(ironHelmetComponent);
            ArmorComponentValue ironHelmetComponentValue = new ArmorComponentValue(4);
            ReceiveComponentValue(ironHelmetComponentValue);
            ItemTypeComponent longswordSubType = new ItemTypeComponent(this);
            Components.Add(longswordSubType);
            ItemTypeComponentValue longswordItemSubType = new ItemTypeComponentValue(Enums.ItemTypes.HeadArmor);
            ReceiveComponentValue(longswordItemSubType);
            
        }
    }
}

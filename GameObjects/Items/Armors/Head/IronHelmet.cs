using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.GameObjects.Items.Armors.Head
{
    public class IronHelmet : Armor
    {
        public IronHelmet() : base("Iron Helmet", Enums.ArmorTypes.Head)
        {
            Value = 10;

            ArmorAttribute ironHelmetAttribute = new ArmorAttribute(this);
            Components.Add(ironHelmetAttribute);
            ArmorMessage ironHelmetMessage = new ArmorMessage(4);
            ReceiveMessage(ironHelmetMessage);
            ItemSubTypeAttribute longswordSubType = new ItemSubTypeAttribute(this);
            Components.Add(longswordSubType);
            ItemSubTypeMessage longswordItemSubType = new ItemSubTypeMessage(Enums.ItemSubTypes.HeadArmor);
            ReceiveMessage(longswordItemSubType);
            
        }
    }
}

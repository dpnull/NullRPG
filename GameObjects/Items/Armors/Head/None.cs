using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.GameObjects.Items.Armors.Head
{
    public class None : Armor
    {
        public None() : base("None", Enums.ArmorTypes.Head)
        {
            ArmorAttribute ironHelmetAttribute = new ArmorAttribute(this);
            Components.Add(ironHelmetAttribute);
            ArmorMessage ironHelmetMessage = new ArmorMessage(0);
            ReceiveMessage(ironHelmetMessage);
            ItemSubTypeAttribute longswordSubType = new ItemSubTypeAttribute(this);
            Components.Add(longswordSubType);
            ItemSubTypeMessage longswordItemSubType = new ItemSubTypeMessage(Enums.ItemSubTypes.HeadArmor);
            ReceiveMessage(longswordItemSubType);
            
        }
    }
}

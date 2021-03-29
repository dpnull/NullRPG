using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.GameObjects.Items.Armors.Head
{
    public class IronHelmet : Item
    {
        public IronHelmet() : base("Iron Helmet", Enums.ItemTypes.Armor)
        {
            ArmorAttribute ironHelmetAttribute = new ArmorAttribute(this);
            Components.Add(ironHelmetAttribute);
            ArmorMessage ironHelmetMessage = new ArmorMessage(4);
            ReceiveMessage(ironHelmetMessage);
        }
    }
}

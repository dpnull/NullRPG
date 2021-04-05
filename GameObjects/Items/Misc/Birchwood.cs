using NullRPG.GameObjects.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.GameObjects.Attributes;

namespace NullRPG.GameObjects.Items.Misc
{
    public class Birchwood : Miscellaneous
    {
        public Birchwood() : base("Birchwood")
        {
            Value = 5;

            ItemSubTypeAttribute birchwoodAtt = new ItemSubTypeAttribute(this);
            Components.Add(birchwoodAtt);

            ItemSubTypeMessage birchwoodMsg = new ItemSubTypeMessage(Enums.ItemSubTypes.Misc);
            ReceiveMessage(birchwoodMsg);
            ItemSubTypeMessage birchwoodMsg2 = new ItemSubTypeMessage(Enums.ItemSubTypes.Material);
            ReceiveMessage(birchwoodMsg2);

        }
    }
}

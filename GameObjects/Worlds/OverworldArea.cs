using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Worlds
{
    public class OverworldArea : Area
    {
        public OverworldArea(string name) : base(name)
        {

        }

        public static OverworldArea Hometown()
        {
            var area = new OverworldArea("Hometown");

            area.AddLocation(OverworldLocation.Blacksmith());
            area.AddLocation(OverworldLocation.Home());

            return area;
        }
    }
}


/*
 * 
        public static void CreateDefault<T>() where T : IEntityInventory
        {
            var inventory = Get<PlayerInventory>();
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {   
                AddSlot<IEntityInventory>(new Slot(inventory.GetUniqueSlotId()));
            }
        }
 * 
 * 
 * 
 */
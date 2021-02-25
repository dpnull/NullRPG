using NullRPG.GameObjects;
using NullRPG.ItemTypes;
using NullRPG.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace NullRPG.Managers
{
    public class CommandManager
    {
        public void EquipItem(Item item)
        {
            if (UserInterfaceManager.Get<ViewItemWindow>().DrawableItem != null)
            {
                if(item is WeaponItem item1)
                {
                    Game.GameSession.Player.Inventory.EquipWeaponItem(item1);
                    
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item.Name);
                } else if(item is HeadItem)
                {
                    Game.GameSession.Player.Inventory.EquipHeadItem((HeadItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item.Name);
                } else if(item is BodyItem)
                {
                    Game.GameSession.Player.Inventory.EquipBodyItem((BodyItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item.Name);
                } else if(item is LegsItem)
                {
                    Game.GameSession.Player.Inventory.EquipLegsItem((LegsItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Item.Name);
                }
            }
        }

        public void Travel(Location loc)
        {
            if(Game.GameSession.Player.GetCurrentLocation().X != loc.X)
            {
                Game.GameSession.Player.TravelToLocation(loc);
                MessageQueue.AddTravelled(loc.Name);
            } else
            {
                MessageQueue.AddColored("You are already at this location.", Color.DarkGoldenrod);
            }
            
            
        }
    }
}

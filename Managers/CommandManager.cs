using NullRPG.GameObjects;
using NullRPG.ItemTypes;
using NullRPG.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.Managers
{
    public class CommandManager
    {
        public void EquipItem(Item item)
        {
            if (UserInterfaceManager.Get<ViewItemWindow>().DrawableItem != null)
            {
                if(item is WeaponItem)
                {
                    Game.GameSession.Player.Inventory.EquipWeapon((WeaponItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Name);
                } else if(item is HeadItem)
                {
                    Game.GameSession.Player.Inventory.EquipHeadItem((HeadItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Name);
                } else if(item is BodyItem)
                {
                    Game.GameSession.Player.Inventory.EquipBodyItem((BodyItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Name);
                } else if(item is LegsItem)
                {
                    Game.GameSession.Player.Inventory.EquipLegsItem((LegsItem)item);
                    MessageQueue.AddItemEquipped(UserInterfaceManager.Get<ViewItemWindow>().DrawableItem.Name);
                }

            }
        }
    }
}

using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using NullRPG.GameObjects;
using SadConsole.Effects;
using NullRPG.ItemTypes;

namespace NullRPG.Windows
{
    public class PreviewWindow : Console, IUserInterface
    {
        private class Coords
        {
            // decrements at the end account for the border
            public const int ITEM_ID_X = 2;
            public const int ITEM_ID_Y = 1;

            public const int ITEM_NAME_X = Constants.Windows.PreviewWidth / 2 - 1;
            public const int ITEM_NAME_Y = 1;

            public const int ITEM_DATA_X = 2;
            public const int ITEM_DATA_Y = 3;

            public const int ITEM_LEVEL_X = 2;
            public const int ITEM_LEVEL_Y = Constants.Windows.PreviewHeight - 2;

            public const int UPGRADE_LEVEL_X = Constants.Windows.PreviewWidth - 3;
            public const int UPGRADE_LEVEL_Y = Constants.Windows.PreviewHeight - 2;

            public const int ITEM_TYPE_X = Constants.Windows.PreviewWidth / 2 - 1;
            public const int ITEM_TYPE_Y = Constants.Windows.PreviewHeight - 2;
        }


        public Console Console { get; set; }

        public int ObjectId { get; set; } = -1;

        public PreviewWindow(int width, int height) : base(width, height)
        {
            Position = new Point(Constants.Windows.PreviewX, Constants.Windows.PreviewY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawItem();

            base.Draw(timeElapsed);
        }

        public void SetObjectForPreview(int objectId)
        {
            if (ItemManager.GetItem<IItem>(objectId) != null)
            {
                ObjectId = objectId;
            } else
            {
                throw new System.Exception($"Object with id_{objectId} could not be found.");
            }
        }

        private void DrawItem()
        {
            if (ObjectId != -1)
            {
                if(ItemManager.GetItem<IItem>(ObjectId) != null)
                {
                    var item = ItemManager.GetItem<IItem>(ObjectId);
            
                    ColoredString itemName = ItemManager.GetItemName<IItem>(ObjectId);
                    

                    this.DrawRectangleTitled(0, 0, Constants.Windows.PreviewWidth - 1, Constants.Windows.PreviewHeight - 1, "+", "-", "|", "|", itemName);

                    List<string> itemData = new List<string>();

                    string itemLevel = $"iLvl {item.Level}";
                    string upgradeLevel = $"uLvl {item.UpgradeLevel}";
                    string itemType = item is WeaponItem ? "[Weapon]" : item is MiscItem ? "[Misc]" : "[UNKNOWN TYPE]";

                    // objects to the ordered list for item attributes
                    string atkData = $"+ {item.MinDmg} - {item.MaxDmg} to attack";
                    string separator = "\0";
                    string valueData = $"Value: {item.Gold}";                  
                    itemData.Add(atkData);
                    itemData.Add(valueData);
                    itemData.Add(separator);

                    int index = 0;
                    foreach (var str in itemData)
                    {
                        Print(Coords.ITEM_DATA_X, Coords.ITEM_DATA_Y + index++, str);
                    }

                    Print(Coords.ITEM_NAME_X - (itemName.Count / 2), Coords.ITEM_NAME_Y, itemName);
                    Print(Coords.ITEM_LEVEL_X, Coords.ITEM_LEVEL_Y, itemLevel);
                    Print(Coords.UPGRADE_LEVEL_X - upgradeLevel.Length, Coords.UPGRADE_LEVEL_Y, upgradeLevel);
                    Print(Coords.ITEM_TYPE_X - (itemType.Length / 2), Coords.ITEM_TYPE_Y, itemType);


                    // unused currently
                    // string itemId = item.ObjectId.ToString();
                    // string itemData = $"{item.MinDmg} - {item.MaxDmg}";
                    //string itemName = Game.GameSession.Player.CurrentWeapon.ObjectId == item.ObjectId ? $"{item.Name} [Equipped]" : $"{item.Name}";
                }
                else
                {
                    throw new System.Exception($"Could not find ObjectId_{ObjectId}.");
                }
        
            }
        }
    }
}

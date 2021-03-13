using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class ItemPreviewWindow : Console, IUserInterface
    {
        private class Coords
        {
            // decrements at the end account for the border
            public const int ITEM_ID_X = 2;

            public const int ITEM_ID_Y = 1;

            public const int ITEM_NAME_X = Constants.Windows.ItemPreviewWidth / 2 - 1;
            public const int ITEM_NAME_Y = 1;

            public const int ITEM_DATA_X = 2;
            public const int ITEM_DATA_Y = 3;

            public const int ITEM_LEVEL_X = 2;
            public const int ITEM_LEVEL_Y = Constants.Windows.ItemPreviewHeight - 2;

            public const int UPGRADE_LEVEL_X = Constants.Windows.ItemPreviewWidth - 3;
            public const int UPGRADE_LEVEL_Y = Constants.Windows.ItemPreviewHeight - 2;

            public const int ITEM_TYPE_X = Constants.Windows.ItemPreviewWidth / 2 - 1;
            public const int ITEM_TYPE_Y = Constants.Windows.ItemPreviewHeight - 2;
        }

        public Console Console { get; set; }

        public int ObjectId { get; set; } = -1;

        public ItemPreviewWindow(int width, int height) : base(width, height)
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
            if (ItemManager.GetItem<IItem>(objectId) != null && ItemManager.GetItem<IItem>(objectId).Name != "None")
            {
                ObjectId = objectId;
                IsVisible = true;
            }
        }

        private void DrawItem()
        {
            if (ObjectId != -1)
            {
                if (ItemManager.GetItem<IItem>(ObjectId) != null)
                {
                    List<ColoredString> itemData = new List<ColoredString>();

                    var item = ItemManager.GetItem<IItem>(ObjectId);

                    ColoredString itemName = ItemManager.GetItemName<IItem>(ObjectId);

                    this.DrawRectangleTitled(0, 0, Constants.Windows.ItemPreviewWidth - 1, Constants.Windows.ItemPreviewHeight - 1, "+", "-", "|", "|", itemName, true);

                    string itemLevel = $"iLvl {item.Level}";
                    string upgradeLevel = $"uLvl {item.UpgradeLevel}";
                    string itemType = item?.GetType().GetCustomAttribute<DescriptionAttribute>(false).Description;

                    // objects to the ordered list for item attributes

                    if (item.MinDmg != 0 && item.MaxDmg != 0)
                    {
                        ColoredString atkData = Extensions.ConsoleExtensions.AttributeString(item.MinDmg, item.MaxDmg, "to attack");
                        itemData.Add(atkData);
                    }
                    if (item.Defense != 0)
                    {
                        ColoredString defenseData = Extensions.ConsoleExtensions.AttributeString(item.Defense, "to defense");
                        itemData.Add(defenseData);
                    }
                    if (item.Gold != 0)
                    {
                        ColoredString valueData = new($"Value: {item.Gold}");
                        itemData.Add(valueData);
                    }

                    // P_HEALTH = 100;
                    // P_DEFENSE = 10;
                    // E_DAMAGE = 20;
                    // Reduction

                    int index = 0;
                    foreach (var str in itemData)
                    {
                        if (str != null)
                        {
                            Print(Coords.ITEM_DATA_X, Coords.ITEM_DATA_Y + index++, str);
                        }
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
using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Components.Item;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class ItemPreviewWindow : Console, IUserInterface
    {
        private class Coords
        {
            public const int DATA_X = 2;
            public const int DATA_Y = 3;
        }

        public int ObjectId { get; set; } = -1;
        public Console Console { get; }

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
            else
            {
                ObjectId = objectId;
                IsVisible = false;
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

                    ColoredString itemName = new ColoredString(item.Name);

                    this.DrawRectangleTitled(0, 0, Constants.Windows.ItemPreviewWidth - 1, Constants.Windows.ItemPreviewHeight - 1, "+", "-", "|", "|", itemName, true);
                    if (ComponentManager.ContainsComponent<WeaponComponent>(item.ObjectId))
                    {
                        int minDmg = item.GetComponent<WeaponComponent>().MinDamage;
                        int maxDmg = item.GetComponent<WeaponComponent>().MaxDamage;

                        ColoredString atkData = Extensions.ConsoleExtensions.AttributeString(minDmg, maxDmg, "to attack");
                        itemData.Add(atkData);
                    }
                    if (ComponentManager.ContainsComponent<ArmorComponent>(item.ObjectId))
                    {
                        int defense = item.GetComponent<ArmorComponent>().Defense;
                        ColoredString defenseData = Extensions.ConsoleExtensions.AttributeString(defense, "to defense");
                        itemData.Add(defenseData);
                    }
                    if (ComponentManager.ContainsComponent<ItemTypeComponent>(item.ObjectId))
                    {
                        string itemType = item.GetComponent<ItemTypeComponent>().ItemTypes.ToString();

                        //Print(Coords.ITEM_TYPE_X - (itemType.Length / 2), Coords.ITEM_TYPE_Y, itemType);
                    }

                    ColoredString value = new ColoredString($"Value: {item.Value}");
                    itemData.Add(value);

                    int index = 0;
                    foreach (var str in itemData)
                    {
                        if (str != null)
                        {
                            Print(Coords.DATA_X, Coords.DATA_Y + index++, str);
                        }
                    }

                    //Print(Coords.ITEM_NAME_X - (itemName.Count / 2), Coords.ITEM_NAME_Y, itemName);
                }
                else
                {
                    throw new System.Exception($"Could not find ObjectId_{ObjectId}.");
                }
            }
        }
    }
}
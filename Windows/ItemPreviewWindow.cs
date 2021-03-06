﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (ItemManager.Get<IItem>(objectId) != null && ItemManager.Get<IItem>(objectId).Name != "None")
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
                if (ItemManager.Get<IItem>(ObjectId) != null)
                {
                    List<ColoredString> itemData = new List<ColoredString>();

                    var item = ItemManager.Get<IItem>(ObjectId);

                    ColoredString itemName = new ColoredString(item.Name);

                    this.DrawRectangleTitled(0, 0, Constants.Windows.ItemPreviewWidth - 1, Constants.Windows.ItemPreviewHeight - 1, "+", "-", "|", "|", itemName, true);

                    DrawWeaponComponent(item, itemData);
                    DrawArmorComponent(item, itemData);
                    //DrawItemTypeComponent(item, itemData);

                    ColoredString value = new ColoredString($"Value: {item.GetComponent<ItemComponents.BaseItemComponent>().Value}");
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

        private void DrawWeaponComponent(IItem item, List<ColoredString> itemData)
        {
            if (item.HasComponent<ItemComponents.Damage>())
            {
                var weaponComponent = item.GetComponent<ItemComponents.Damage>();

                int minDmg = weaponComponent.MinDamage;
                int maxDmg = weaponComponent.MaxDamage;

                ColoredString atkData = Extensions.ConsoleExtensions.AttributeString(minDmg, maxDmg, "to attack");
                itemData.Add(atkData);
            }
        }

        private void DrawArmorComponent(IItem item, List<ColoredString> itemData)
        {
            if (item.HasComponent<ItemComponents.Defense>())
            {
                var armorComponent = item.GetComponent<ItemComponents.Defense>();

                var defense = armorComponent.BaseDefense;

                ColoredString defenseData = Extensions.ConsoleExtensions.AttributeString(defense, "to defense");
                itemData.Add(defenseData);
            }
        }

        /*
        private void DrawItemTypeComponent(IItem item, List<ColoredString> itemData)
        {
            if ()
            {
                var itemTypeComponent = item.GetComponent<ItemTypeComponent>();

                var itemType = item.GetComponent<ItemTypeComponent>().ItemTypes.FirstOrDefault().ToString();

                itemData.Add(new ColoredString(itemType));
            }
        }
        */
    }
}
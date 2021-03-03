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
            public const int ITEM_ID_X = 1;
            public const int ITEM_ID_Y = 1;

            public const int ITEM_TYPE_X = Constants.Windows.PreviewWidth - 10;
            public const int ITEM_TYPE_Y = 1;

            public const int ITEM_NAME_X = 1;
            public const int ITEM_NAME_Y = 2;

            public const int ITEM_DATA_X = 1;
            public const int ITEM_DATA_Y = 3;
        }


        public Console Console { get; set; }

        public int ObjectId { get; set; } = -1;

        public PreviewWindow(int width, int height) : base(width, height)
        {
            Position = new Point(20, 10); // temp

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

                    string itemId = item.ObjectId.ToString();
                    string itemName = Game.GameSession.Player.CurrentWeapon.ObjectId == item.ObjectId ? $"{item.Name} [Equipped]" : $"{item.Name}";
                    string itemType = item is WeaponItem ? "Weapon" : item is MiscItem ? "Misc" : "UNKNOWN TYPE";
                    string itemData = $"{item.MinDmg} - {item.MaxDmg}";

                    // todo: draw borders

                    Print(Coords.ITEM_ID_X, Coords.ITEM_ID_Y, itemId);
                    Print(Coords.ITEM_DATA_X, Coords.ITEM_DATA_Y, itemData);
                    Print(Coords.ITEM_TYPE_X, Coords.ITEM_TYPE_Y, itemType);
                    Print(Coords.ITEM_NAME_X, Coords.ITEM_NAME_Y, itemName);
                }
                else
                {
                    throw new System.Exception($"Could not find ObjectId_{ObjectId}.");
                }
        
            }
        }
    }
}

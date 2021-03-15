﻿using Microsoft.Xna.Framework;
using NullRPG.Interfaces;
using SadConsole;
using System.Collections.Generic;
using System.Linq;
using static NullRPG.GameObjects.Item;

namespace NullRPG.Managers
{
    public static class ItemManager
    {
        public static Dictionary<Rarities, string> RarityGlyphs = InitializeRarityGlyphsDictionary();

        public static int GetUniqueId()
        {
            return ItemDatabase.GetUniqueId();
        }

        public static Dictionary<Rarities, string> InitializeRarityGlyphsDictionary()
        {
            var dictionary = new Dictionary<Rarities, string>();

            (Rarities, string)[] rarityGlyphs = new (Rarities, string)[]
            {
                (Rarities.Common, "-"),
                (Rarities.Uncommon, "="),
                (Rarities.Rare, "+"),
                (Rarities.VeryRare, "*"),
                (Rarities.Legendary, "**")
                // todo: add reversing of glyphs
            };

            foreach (var glyph in rarityGlyphs)
            {
                dictionary.Add(glyph.Item1, glyph.Item2);
            }

            return dictionary;
        }

        public static string GetRarityGlyph(Rarities rarity)
        {
            return RarityGlyphs.TryGetValue(rarity, out string value) ? value : null;
        }

        // called automatically when creating a new item
        public static void Add(IItem item)
        {
            if (!ItemDatabase.Items.ContainsKey(item.ObjectId))
            {
                ItemDatabase.Items.Add(item.ObjectId, item);
            }
        }

        public static void Remove(IItem item)
        {
            // Don't remove id 1 which is reveserved for "None" weapon item
            if (Game.GameSession.Player.Inventory.CurrentWeapon.ObjectId == item.ObjectId)
            {
                InventoryManager.EquipItem<IEntityInventory>(GetItem<IItem>(0).ObjectId);
            }
            ItemDatabase.Items.Remove(item.ObjectId);
        }

        public static T[] GetItems<T>() where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray().OfType<T>();
            return collection.ToArray();
        }

        public static T GetItem<T>(int objectId) where T : IItem
        {
            var collection = ItemDatabase.Items.Values.ToArray();
            foreach (var item in collection)
            {
                return (T)ItemDatabase.Items.Values.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }

        public static ColoredString GetItemName<T>(int objectId) where T : IItem
        {
            var item = GetItem<T>(objectId);

            ColoredString lRarityGlyph = new ColoredString(GetRarityGlyph(item.Rarity));
            ColoredString rRarityGlyph = new ColoredString(GetRarityGlyph(item.Rarity));
            Color c = item.Enchantment == Enchantments.Fire ? Color.OrangeRed : item.Enchantment == Enchantments.Steel ? Color.LightSlateGray : Color.White;
            ColoredString prefix = new ColoredString($"{item.Enchantment}", c, Constants.Theme.BackgroundColor);
            ColoredString suffix = new ColoredString($"{item.Name}", Constants.Theme.ForegroundColor, Constants.Theme.BackgroundColor);
            if (item.Enchantment != Enchantments.Default)
            {
                return lRarityGlyph + prefix + " " + suffix + rRarityGlyph;
            }
            else
            {
                return lRarityGlyph + suffix + rRarityGlyph;
            }
        }
    }

    public static class ItemDatabase
    {
        public static readonly Dictionary<int, IItem> Items = new Dictionary<int, IItem>();

        private static int _currentId;

        public static int GetUniqueId()
        {
            return _currentId++;
        }
    }
}
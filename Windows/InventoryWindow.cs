﻿using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Attributes;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using static NullRPG.Input.Keybinding;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class InventoryWindow : Console, IUserInterface
    {
        public Console Console => this;
        public IIndexedKeybinding[] IndexedKeybindings { get; private set; }
        public InventoryWindow(int width, int height) : base(width, height)
        {
            Position = new Point(0, 1);

            Global.CurrentScreen.Children.Add(this);
        }
        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

            DrawCurrentWeapon();
            
            base.Draw(timeElapsed);
        }

        private void DrawCurrentWeapon()
        {
            var weapon = Game.GameSession.PlayerInventory.WeaponSlot;

            var minDmg = weapon.GetAttribute<WeaponAttribute>().MinDamage;
            var maxDmg = weapon.GetAttribute<WeaponAttribute>().MaxDamage;

            Print(0, 4, weapon.Name);
            Print(0, 5, $"{minDmg} - {maxDmg}");
            Print(0, 7, weapon.ItemType.ToString());

            var armor = Game.GameSession.PlayerInventory.HeadSlot;

            var defense = armor.GetAttribute<ArmorAttribute>().Defense;

            Print(0, 9, defense.ToString());
        }

    }
}

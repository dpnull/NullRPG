﻿using NullRPG.Interfaces;
using NullRPG.ItemTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG.GameObjects
{
    public abstract class EntityInventory : IEntityInventory
    {
        public Dictionary<int, ISlot> Slots { get; set; }

        public WeaponItem CurrentWeapon { get; set; }

        public EntityInventory()
        {
            Slots = new Dictionary<int, ISlot>();
        }

        private int _currentId;
        public int GetUniqueSlotId()
        {
            return _currentId++;
        }
        public string GetWeaponName()
        {
            return CurrentWeapon?.Name.ToString();
        }
    }
}

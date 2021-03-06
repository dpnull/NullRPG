﻿using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public abstract class BaseInventory : IEntityInventory
    {
        public int ObjectId { get; set; }
        public Dictionary<int, ISlot> Slots { get; set; }

        public BaseInventory()
        {
            ObjectId = InventoryManager.GetUniqueEntityInventoryId();
            InventoryManager.AddInventory(this);
            

            Slots = new Dictionary<int, ISlot>();

            InventoryManager.CreateDefaultInventory(this);
        }
    }
}

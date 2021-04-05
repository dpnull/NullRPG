﻿using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseEntity : IEntity
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public List<IEntityComponent> Components { get; set; } = new List<IEntityComponent>();

        public BaseEntity()
        {
            ObjectId = EntityManager.GetUniqueId();
        }

        public T GetComponent<T>() where T : IEntityComponent
        {
            return Components.OfType<T>().FirstOrDefault();
        }

        public void ReceiveComponentValue<T>(T value)
        {
            foreach (IEntityComponent component in Components)
            {
                component.ReceiveValue<T>(value);
            }
        }
    }
}

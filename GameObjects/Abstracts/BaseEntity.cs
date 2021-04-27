using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseEntity : ComponentSystemEntity, IEntity
    {
        public BaseEntity(string name) : base(name, EntityManager.GetUniqueId())
        {
            EntityManager.Add(this);
        }
    }
}

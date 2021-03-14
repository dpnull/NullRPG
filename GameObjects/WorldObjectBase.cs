using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects
{
    public abstract class WorldObjectBase : IWorldObject
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public List<IItem> Items { get; set; }
        public Objects ObjectType { get; set; }
        public ObjectActions ObjectActionType { get; set; }

        public enum Objects
        {
            None,
            Tree
        }

        public enum ObjectActions
        {
            None,
            Chop
        }

        public WorldObjectBase(string name, List<IItem> items, Objects objectType, ObjectActions objectActionType)
        {
            ObjectId = WorldObjectManager.GetUniqueWorldObjectId();
            WorldObjectManager.AddWorldObject(this);

            Name = name;
            Items = items;
            ObjectType = objectType;
            ObjectActionType = objectActionType;
        }
    }
}

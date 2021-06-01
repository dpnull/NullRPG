using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class ActorManager
    {
        public static T Get<T>(int objectId) where T : IActor
        {
            var collection = ECSManager.Get<T>();
            foreach(var item in collection)
            {
                return collection.SingleOrDefault(i => i.ObjectId == objectId);
            }

            return default;
        }
    }
}

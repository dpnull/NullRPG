using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface ISlot : IIndexable
    {
        public List<IItem> Item { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IItem
    {
        int ObjectId { get; set; }
        Enums.ItemCategories ItemCategory { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        //bool CanEquip { get; set; }
        bool IsStackable { get; set; }
        public List<IItemComponent> Components { get; set; }
        /// <summary>
        /// Replace the IEntityComponent values to the new values from the IEntityComponentValue object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the IEntityComponent interface.</typeparam>
        /// <param name="value">A type that inherits from the IEntityComponentValue interface.</param>
        void ReceiveComponentValue<T>(T message);
        /// <summary>
        /// Retrieve an IItemComponent of the passed type from the list of Components.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the IItemComponent interface.</typeparam>
        /// <returns>The first matching component.</returns>
        public T GetComponent<T>() where T : IItemComponent;
    }
}

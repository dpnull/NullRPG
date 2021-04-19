using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ILocation : IIndexable
    {
        int ObjectId { get; set; }
        string Name { get; set; }
        int Level { get; set; }

        public List<ILocationComponent> Components { get; set; }

        /// <summary>
        /// Replace the ILocationComponent values to the new values from the ILocationComponentValue object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the ILocationComponent interface.</typeparam>
        /// <param name="value">A type that inherits from the ILocationComponentValue interface.</param>
        void ReceiveComponentValue<T>(T message);

        /// <summary>
        /// Retrieve an ILocationComponent of the passed type from the list of Components.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the ILocationComponent interface.</typeparam>
        /// <returns>The first matching component.</returns>
        public T GetComponent<T>() where T : ILocationComponent;
    }
}

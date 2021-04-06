using System.Collections.Generic;

namespace NullRPG.Interfaces
{
    public interface IEntity
    {
        int ObjectId { get; set; }
        public string Name { get; set; }
        public List<IEntityComponent> Components { get; set; }

        /// <summary>
        /// Replace the IEntityComponent values to the new values from the IEntityComponentValue object.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the IEntityComponent interface.</typeparam>
        /// <param name="value">A type that inherits from the IEntityComponentValue interface.</param>
        void ReceiveComponentValue<T>(T value);

        /// <summary>
        /// Retrieve an IEntityComponent of the passed type from the list of Components.
        /// </summary>
        /// <typeparam name="T">A type that inherits from the IEntityComponent interface.</typeparam>
        /// <returns>The first matching component.</returns>
        public T GetComponent<T>() where T : IEntityComponent;
    }
}
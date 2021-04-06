namespace NullRPG.Interfaces
{
    public interface IEntityComponent
    {
        IEntity Source { get; set; }

        void ReceiveValue<T>(T value);
    }
}
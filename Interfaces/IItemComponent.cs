namespace NullRPG.Interfaces
{
    public interface IItemComponent
    {
        IItem Source { get; set; }

        void ReceiveValue<T>(T value);
    }
}
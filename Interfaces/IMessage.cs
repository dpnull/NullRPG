namespace NullRPG.Interfaces
{
    public interface IMessage
    {
        int ObjectId { get; set; }
        SadConsole.ColoredString ColoredString { get; set; }
    }
}
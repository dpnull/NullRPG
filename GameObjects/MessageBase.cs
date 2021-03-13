using NullRPG.Interfaces;

namespace NullRPG.GameObjects
{
    internal class MessageBase : IMessage
    {
        public int ObjectId { get; set; }
        public SadConsole.ColoredString ColoredString { get; set; }

        public MessageBase(SadConsole.ColoredString coloredString)
        {
            ObjectId = MessageManager.GetUniqueMessageId();
            MessageManager.AddToDatabase(this);

            ColoredString = coloredString;
        }
    }
}
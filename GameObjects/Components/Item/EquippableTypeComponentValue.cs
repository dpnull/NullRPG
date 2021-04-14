namespace NullRPG.GameObjects.Components.Item
{
    public class EquippableTypeComponentValue
    {
        public Enums.EquippableTypes EquippableType { get; private set; }

        public EquippableTypeComponentValue(Enums.EquippableTypes equippableType)
        {
            EquippableType = equippableType;
        }
    }
}

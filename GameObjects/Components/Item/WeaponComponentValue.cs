namespace NullRPG.GameObjects.Components.Item
{
    public class WeaponComponentValue
    {
        public int MinDamage;
        public int MaxDamage;

        public WeaponComponentValue(int minDamage, int maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
namespace NullRPG
{
    public static class Constants
    {
        public const string GameTitle = "NullRPG";
        public const string Build = "Build 280222";

        public const int GameWidth = 80;
        public const int GameHeight = 26;

        public static class Windows
        {
            public const int TitleWidth = GameWidth;
            public const int TitleHeight = GameHeight - 1;

            public const int HelpWidth = GameWidth;
            public const int HelpHeight = GameHeight - 1;

            public const int StatsWidth = GameWidth;
            public const int StatsHeight = 3;

            public const int KeybindingsWidth = GameWidth;
            public const int KeybindingsHeight = 3;

            public const int CharacterWidth = GameWidth;
            public const int CharacterHeight = GameHeight - KeybindingsHeight - 1;

            public const int InventoryWidth = GameWidth;
            public const int InventoryHeight = GameHeight - KeybindingsHeight - 1;
        }
    }
}

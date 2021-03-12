using Microsoft.Xna.Framework;
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
            
            public const int KeybindingsWidth = GameWidth;
            public const int KeybindingsHeight = 8;
            public const int KeybindingsX = 0;
            public const int KeybindingsY = GameHeight - KeybindingsHeight;

            public const int GeneralKeybindingsWidth = GameWidth / 3;
            public const int GeneralKeybindingsHeight = KeybindingsHeight;
            public const int GeneralKeybindingsX = KeybindingsWidth - GeneralKeybindingsWidth;
            public const int GeneralKeybindingsY = 0;

            public const int LocationKeybindingsWidth = GameWidth / 3;
            public const int LocationKeybindingsHeight = KeybindingsHeight;
            public const int LocationKeybindingsX = KeybindingsWidth - GeneralKeybindingsWidth - LocationKeybindingsWidth;
            public const int LocationKeybindingsY = 0;

            public const int CharacterKeybindingsWidth = GameWidth;
            public const int CharacterKeybindingsHeight = KeybindingsHeight;

            public const int MessageWidth = GameWidth;
            public const int MessageHeight = 2;
            public const int MessageX = 0;
            public const int MessageY = GameHeight - KeybindingsHeight - MessageHeight;

            public const int HelpWidth = GameWidth;
            public const int HelpHeight = GameHeight - 1;

            public const int StatsWidth = GameWidth;
            public const int StatsHeight = 3;

            public const int CharacterWidth = GameWidth;
            public const int CharacterHeight = GameHeight - KeybindingsHeight - MessageHeight;

            public const int InventoryWidth = GameWidth;
            public const int InventoryHeight = GameHeight - KeybindingsHeight - MessageHeight;

            public const int ItemPreviewWidth = 40;
            public const int ItemPreviewHeight = 10;
            public const int PreviewX = InventoryWidth - ItemPreviewWidth;
            public const int PreviewY = (InventoryHeight - ItemPreviewHeight) / 2 + 2;

            public const int TravelWidth = GameWidth;
            public const int TravelHeight = GameHeight - KeybindingsHeight - 1;


        }

        public static class Theme
        {
            public static readonly Color BackgroundColor = Color.Black;
            public static readonly Color ForegroundColor = Color.White;

            public static readonly Color ButtonKeyColor = Color.Green;

            public static readonly Color PositiveAttributeColor = Color.LightGreen;
            public static readonly Color NegativeAttributeColor = Color.Red;

            public static readonly Color HeaderForegroundColor = Color.Gold;
            public static readonly Color HeaderBackgroundColor = Color.Black;
        }
    }
}

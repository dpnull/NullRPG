using Microsoft.Xna.Framework;

namespace NullRPG
{
    public static class Constants
    {
        public const string GameTitle = "NullRPG";
        public const string GameBuildVersion = "07042021";

        public const int GameWidth = 80;
        public const int GameHeight = 26;

        public static class Windows
        {
            public static class Keybindings
            {
                public const int GeneralWidth = 20;
                public const int GeneralHeight = KeybindingsHeight;
                public const int GeneralX = KeybindingsWidth - GeneralWidth;
                public const int GeneralY = 0;

                public const int LocationWidth = 30;
                public const int LocationHeight = KeybindingsHeight;
                public const int LocationX = KeybindingsWidth - GeneralWidth - LocationWidth;
                public const int LocationY = 0;
            }

            public const int KeybindingsWidth = GameWidth;
            public const int KeybindingsHeight = 8;
            public const int KeybindingsX = 0;
            public const int KeybindingsY = GameHeight - KeybindingsHeight;

            public const int GameWindowWidth = GameWidth;
            public const int GameWindowHeight = GameHeight - 1;
            public const int GameWindowX = 0;
            public const int GameWindowY = 1;

            public const int MainMenuWidth = GameWidth;
            public const int MainMenuHeight = GameHeight;
            public const int MainMenuX = 0;
            public const int MainMenuY = 0;

            public const int InventoryWidth = GameWidth;
            public const int InventoryHeight = GameHeight - KeybindingsHeight;

            public const int CharacterWidth = GameWidth;
            public const int CharacterHeight = GameHeight - KeybindingsHeight;

            public const int ItemPreviewWidth = 40;
            public const int ItemPreviewHeight = 12;
            public const int PreviewX = InventoryWidth - ItemPreviewWidth;
            public const int PreviewY = (InventoryHeight - ItemPreviewHeight) / 2 - 1;

            public const int MessageWidth = GameWidth;
            public const int MessageHeight = 2;
            public const int MessageX = 0;
            public const int MessageY = GameHeight - KeybindingsHeight - MessageHeight;

            public const int StatWidth = GameWidth;
            public const int StatHeight = 3;
            public const int StatX = 0;
            public const int StatY = 4;

            public const int TravelWidth = GameWidth;
            public const int TravelHeight = GameHeight - KeybindingsHeight - MessageHeight;
            public const int TravelX = 0;
            public const int TravelY = 1;

        }

        public static class Theme
        {
            public static Color DefaultForeground = Color.White;
            public static Color DefaultBackground = Color.Black;

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
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NullRPG
{
    public static class Constants
    {
        public const string GameTitle = "NullRPG";
        public const string GameBuildVersion = "28032021";

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
        }
        public static class Theme
        {
            public static Color DefaultForeground = Color.White;
            public static Color DefaultBackground = Color.Black;
        }
    }
}

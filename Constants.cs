﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG
{
    public sealed class Constants
    {
        public const string GameTitle = "NullRPG";
        public const string Build = "Build 210222";

        public const int GameWidth = 80;
        public const int GameHeight = 25;

        public class Windows
        {
            public const int TitleWidth = 80;
            public const int TitleHeight = 25;

            public const int HelpWidth = 80;
            public const int HelpHeight = 25;

            public const int StatsWidth = 80;
            public const int StatsHeight = 3;

            public const int KeybindingsWidth = 80;
            public const int KeybindingsHeight = 3;

            public const int TravelWidth = GameWidth;
            public const int TravelHeight = GameHeight - 1 - KeybindingsHeight;

            public const int LocationWidth = 25;
            public const int LocationHeight = 6;

            public const int CharacterWidth = GameWidth;
            public const int CharacterHeight = GameHeight - KeybindingsHeight - 1;

            public const int InventoryWidth = GameWidth;
            public const int InventoryHeight = GameHeight;

            public const int ViewItemWidth = 40;
            public const int ViewItemHeight = 10;

            public const int MessageWidth = GameWidth;
            public const int MessageHeight = 2;
        }
    }
}

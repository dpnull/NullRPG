﻿using NullRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NullRPG
{
    public class GameSession
    {
        public Player Player { get; set; }
        public GameSession()
        {
            Player = new Player("Tianyu", 100, 100, 37, 0, 1, Player.PlayableClass.Warrior);
        }
    }
}

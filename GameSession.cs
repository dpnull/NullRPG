using NullRPG.GameObjects.Entity;
using NullRPG.GameObjects.Items.Armors.Head;
using NullRPG.GameObjects.Items.Misc;
using NullRPG.GameObjects.Items.Weapons;
using NullRPG.Interfaces;
using NullRPG.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG
{
    public class GameSession
    {
        public Player Player { get; private set; }
        public GameSession()
        {
            IndexedKeybindingsManager.Initialize();
            Player = EntityManager.Create<Player>();


        }
    }
}

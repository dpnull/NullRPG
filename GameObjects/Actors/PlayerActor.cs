using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Console = SadConsole;
using SadConsole;
using NullRPG.GameObjects.Abstracts;

namespace NullRPG.GameObjects.Actors
{
    public class PlayerActor : BaseActor
    {
        public PlayerActor() : base(Color.Green, Color.Transparent, '@') { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Console = SadConsole;
using SadConsole;
using NullRPG.Interfaces;
using NullRPG.Managers;

namespace NullRPG.GameObjects.Abstracts
{
    public class BaseActor : ComponentSystemEntity, IActor
    {
        public SadConsole.Entities.Entity Actor;

        public BaseActor(Color foreground, Color background, int glyph) : base("Actor")
        {
            ECSManager.AddEntity(this);
            CreateActor(foreground, background, glyph);
        }

        private void CreateActor(Color foreground, Color background, int glyph, int width = 1, int height = 1)
        {
            Actor = new SadConsole.Entities.Entity(foreground, background, glyph);

            Actor.Animation.CurrentFrame[0].Foreground = foreground;
            Actor.Animation.CurrentFrame[0].Background = background;
            Actor.Animation.CurrentFrame[0].Glyph = glyph;
        }


    }
}

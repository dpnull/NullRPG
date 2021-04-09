using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using SadConsole.Input;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class StatWindow : Console, IUserInterface
    {
        public StatWindow(int width, int height) : base(width, height)
        {
            Position = new Microsoft.Xna.Framework.Point(Constants.Windows.StatWidth, Constants.Windows.StatHeight);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            base.Draw(timeElapsed);
        }

        private void DrawStats()
        {
            var player = EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId);

            string name = player.Name;
            
        }
    }
}

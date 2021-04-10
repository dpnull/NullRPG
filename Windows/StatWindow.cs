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
using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Components.Entity;

namespace NullRPG.Windows
{
    public class StatWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public StatWindow(int width, int height) : base(width, height)
        {
            Position = new Microsoft.Xna.Framework.Point(Constants.Windows.StatX, Constants.Windows.StatY);

            DefaultBackground = Color.Red;

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            DrawStats();
            
            base.Draw(timeElapsed);
        }

        private void DrawStats()
        {
            DrawPlayerLocation();
            
        }

        private void DrawPlayerLocation()
        {
            var player = EntityManager.Get<IEntity>(Game.GameSession.Player.ObjectId);
            var location = player.GetComponent<PositionComponent>().Location;
            var area = player.GetComponent<PositionComponent>().Area;
            var world = player.GetComponent<PositionComponent>().World;

            string[] printable = new string[]
            {
                $"Current location: {location.Name}",
                $"Current area: {area.Name}",
                $"Current world: {world.Name}"
            };

            int _y = 0;
            foreach(var p in printable)
            {
                Print(1, _y, p); _y++;
            }
        }
    }
}

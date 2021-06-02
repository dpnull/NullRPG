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

namespace NullRPG.Windows
{
    public class StatWindow : Console, IUserInterface
    {
        public Console Console { get; }
        public StatWindow(int width, int height) : base(width, height)
        {
            Position = new Microsoft.Xna.Framework.Point(Constants.Windows.StatX, Constants.Windows.StatY);

            Global.CurrentScreen.Children.Add(this);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            Clear();

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
            var location = player.GetComponent<EntityComponents.WorldPosition>().Location;
            var area = player.GetComponent<EntityComponents.WorldPosition>().Area;
            string locObject;

            List<string> printable = new List<string>
            {
                $"Current location: {location.Name}",
                $"Current area: {area.Name}",
            };

            if (location.HasComponent<LocationComponents.LocationObjectComponent>())
            {
                locObject = location.GetComponent<LocationComponents.LocationObjectComponent>().LocationObjects.FirstOrDefault().Name;
                printable.Add(locObject);
            }

            int _y = 0;
            foreach(var p in printable)
            {
                Print(1, _y, p); _y++;
            }
        }
    }
}

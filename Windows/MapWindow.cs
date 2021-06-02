using Microsoft.Xna.Framework;
using NullRPG.Extensions;
using NullRPG.GameObjects.Actors;
using NullRPG.GameObjects.Blueprints.Objects;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using NullRPG.Windows.Editor;
using SadConsole;
using SadConsole.Input;
using System;
using System.Linq;
using Console = SadConsole.Console;

namespace NullRPG.Windows
{
    public class MapWindow : ScrollingConsole, IUserInterface
    {
        public Console Console { get; }



        public MapWindow(int width, int height) : base(width, height, new Rectangle(0, 0, Constants.Windows.MapWidth, 20))
        {
          

            Position = new Point(Constants.Windows.MapX, Constants.Windows.MapY);

            Global.CurrentScreen.Children.Add(this);
        }

        public void Initialize()
        {
            GridManager.InitializeBlueprint<TownBlueprint>(true);
            GridManager.Grid.RenderObject(this);
        }

        /// <summary>
        /// Call this method when you change the cell colors on the cell objects.
        /// </summary>
        public void Update()
        {
            IsDirty = true;
        }

        public void CenterOnEntity(IMapEntity entity)
        {
            this.CenterViewPortOnPoint(entity.Position);
        }
    }
}

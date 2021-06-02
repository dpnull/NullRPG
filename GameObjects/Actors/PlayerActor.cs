using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Console = SadConsole;
using SadConsole;
using NullRPG.GameObjects.Abstracts;
using NullRPG.Managers;
using NullRPG.Windows;
using SadConsole.Components;
using static SadConsole.Entities.Entity;
using SadConsole.Input;
using static NullRPG.Input.Keybinding;
using GoRogue;
using NullRPG.Interfaces;

namespace NullRPG.GameObjects.Actors
{
    public class PlayerActor : BaseMapEntity
    {
        private MapWindow _mapWindow;
        public MapWindow MapWindow => _mapWindow ??= UserInterfaceManager.Get<MapWindow>();
        private readonly FovWindow _fovObjectsWindow;
        public PlayerActor() : base(Color.Green, Color.Transparent, '@')
        {
            FieldOfViewRadius = 10;
            // interactionstatus todo here <<
            _fovObjectsWindow = UserInterfaceManager.Get<FovWindow>();
            Components.Add(new EntityViewSyncComponent());
        }

        public override void OnMove(object sender, EntityMovedEventArgs args)
        {

            // OnMove will redraw fov, and flashlight needs to be handled before that
            base.OnMove(sender, args);

            // Update visible objects in fov window
            _fovObjectsWindow.Update(this);
        }


        public void Initialize(bool addRenderObject = true)
        {
            if (addRenderObject)
            {
                // Draw player on the map
                RenderObject(MapWindow);
            }

            // Make sure we check for input
            IsFocused = true;

            // Center viewport on player
            MapWindow.CenterOnEntity(this);

            // Show the nearby objects in the fov window
            _fovObjectsWindow.Update(this);

            // Render map
            MapWindow.IsDirty = true;
        }


    }
}

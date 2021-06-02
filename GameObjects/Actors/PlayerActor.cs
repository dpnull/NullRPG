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

namespace NullRPG.GameObjects.Actors
{
    public class PlayerActor : BaseActor
    {
        private MapWindow _mapWindow;
        public MapWindow MapWindow => _mapWindow ??= UserInterfaceManager.Get<MapWindow>();
        private readonly FovWindow _fovObjectsWindow;
        public PlayerActor() : base(Color.Green, Color.Transparent, '@')
        {
            FieldOfViewRadius = 10;
            // interactionstatus todo here <<
            Actor.Components.Add(new EntityViewSyncComponent());


        }

        public override void OnMove(object sender, EntityMovedEventArgs args)
        {

            // OnMove will redraw fov, and flashlight needs to be handled before that
            base.OnMove(sender, args);

            // Update visible objects in fov window
            _fovObjectsWindow.Update(this);
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            bool keyHandled = false;

            // Simplified way to check if any key we care about is pressed and set movement direction.
            foreach (var key in _playerMovements.Keys)
            {
                var binding = KeybindingManager.GetKeybinding(key);
                if (info.IsKeyPressed(binding))
                {
                    var moveDirection = _playerMovements[key];
                    MoveTowards(moveDirection);
                    keyHandled = true;
                    break;
                }
            }

            if (keyHandled)
                return true;
            else
                return base.ProcessKeyboard(info);
        }

        public void Initialize(bool addRenderObject = true)
        {
            if (addRenderObject)
            {
                // Draw player on the map
                RenderObject(MapWindow);
            }

            // Make sure we check for input
            Actor.IsFocused = true;

            // Center viewport on player
            MapWindow.CenterOnEntity(this);

            // Show the nearby objects in the fov window
            _fovObjectsWindow.Update(this);

            // Render map
            MapWindow.IsDirty = true;
        }

        private readonly Dictionary<Keybindings, Direction> _playerMovements =
        new Dictionary<Keybindings, Direction>
        {
            {Keybindings.Movement_Up, Direction.UP},
            {Keybindings.Movement_Down, Direction.DOWN},
            {Keybindings.Movement_Left, Direction.LEFT},
            {Keybindings.Movement_Right, Direction.RIGHT}
        };
    }
}

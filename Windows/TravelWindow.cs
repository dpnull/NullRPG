using System;
using System.Collections.Generic;
using System.Text;
using NullRPG.Interfaces;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using SadConsole.Input;
using NullRPG.GameObjects;
using SadConsole.Controls;
using SadConsole.Themes;

namespace NullRPG.Windows
{
    public class TravelWindow : Console, IUserInterface
    {
        IndexKeybindings indexKeybindings;
        private Dictionary<int, Microsoft.Xna.Framework.Input.Keys> IndexDictionary = new Dictionary<int, Microsoft.Xna.Framework.Input.Keys>();

        private void InitializeIndexDictionary()
        {
            (int, Microsoft.Xna.Framework.Input.Keys)[] indexedKeybindings = new (int, Microsoft.Xna.Framework.Input.Keys)[]
            {
                (0, Microsoft.Xna.Framework.Input.Keys.D1),
                (1, Microsoft.Xna.Framework.Input.Keys.D2),
                (2, Microsoft.Xna.Framework.Input.Keys.D3),
                (3, Microsoft.Xna.Framework.Input.Keys.D4),
                (4, Microsoft.Xna.Framework.Input.Keys.D5),
                (5, Microsoft.Xna.Framework.Input.Keys.D6),
                (6, Microsoft.Xna.Framework.Input.Keys.D7),
                (7, Microsoft.Xna.Framework.Input.Keys.D8),
                (8, Microsoft.Xna.Framework.Input.Keys.D9),
            };

            foreach(var indexedKeybinding in indexedKeybindings)
            {
                IndexDictionary.Add(indexedKeybinding.Item1, indexedKeybinding.Item2);
            }
        }

        private Microsoft.Xna.Framework.Input.Keys GetKeybinding(int index)
        {
            if (IndexDictionary.TryGetValue(index, out Microsoft.Xna.Framework.Input.Keys value)) return value;
            throw new System.Exception($"No keybinding defined with index: {index}");
        }

        public Console Console
        {
            get { return this; }
        }

        public TravelWindow(int width, int height) : base(width, height)
        {
            InitializeIndexDictionary();

            indexKeybindings = new IndexKeybindings();
            CreateIndexKeybindings(Game.GameSession.World);

            Global.CurrentScreen.Children.Add(this);
        }


        private void CreateIndexKeybindings(World world)
        {
            for(int i = 0; i < world.GetLocations().Length; i++)
            {
                indexKeybindings.AddIndexedKeybinding(i, GetKeybinding(i), world.GetLocations()[i]);
            }
        }

        public override void Update(TimeSpan timeElapsed)
        {
            DrawLocations(Game.GameSession.World);
            base.Update(timeElapsed);
        }

        private void DrawLocations(World world)
        {
            for (int i = 0; i < world.GetLocations().Length; i++)
            {
                this.PrintButton(0, i, world.GetLocations()[i].Name, char.Parse(indexKeybindings._indexKeybindings[i].Index.ToString()), Color.Green, false);
            }
        }

        public override bool ProcessKeyboard(Keyboard info)
        {
            if (info.IsKeyPressed(Keybindings.GetKeybinding(Keybindings.Type.Cancel)))
            {
                CloseTravelWindow();
                return true;
            }

            if (info.IsKeyPressed(indexKeybindings.GetKeybinding(1).Keybinding))
            {
                Travel(indexKeybindings.GetKeybinding(1).Location.X);
                return true;
            }
            
            if (info.IsKeyPressed(indexKeybindings.GetKeybinding(2).Keybinding))
            {
                Travel(indexKeybindings.GetKeybinding(2).Location.X);
                return true;
            }

            if (info.IsKeyPressed(indexKeybindings.GetKeybinding(3).Keybinding))
            {
                Travel(indexKeybindings.GetKeybinding(3).Location.X);
                return true;
            }


            return false;
        }

        private void Travel(int x)
        {
            Game.GameSession.Player.TravelToLocation(Game.GameSession.World, x);
        }

        private void CloseTravelWindow()
        {
            this.TransitionVisibilityAndFocus(UserInterfaceManager.Get<GameWindow>());
        }

        internal class IndexKeybindings
        {
            public List<IndexKeybinding> _indexKeybindings = new List<IndexKeybinding>();

            internal void AddIndexedKeybinding(int index, Microsoft.Xna.Framework.Input.Keys keybinding, Location location)
            {
                IndexKeybinding indexKeybinding = new IndexKeybinding();

                indexKeybinding.Index = index;
                indexKeybinding.Keybinding = keybinding;
                indexKeybinding.Location = location;

                _indexKeybindings.Add(indexKeybinding);
            }

            internal IndexKeybinding GetKeybinding(int index)
            {
                foreach(var keybinding in _indexKeybindings)
                {
                    if(index == keybinding.Index)
                    {
                        return keybinding;
                    }                
                }

                return null;
            }
        }

        internal class IndexKeybinding
        {
            private int _index;
            public int Index
            {
                get { return _index; }
                set
                {
                    _index = value;
                    _index += 1;
                }
            }
            public Microsoft.Xna.Framework.Input.Keys Keybinding { get; set; }
            public Location Location { get; set; }
        }
    }


}

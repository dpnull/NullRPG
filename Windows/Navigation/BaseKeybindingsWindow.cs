using NullRPG.Interfaces;
using System;
using SadConsole;
using Console = SadConsole.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NullRPG.Input;
using NullRPG.Extensions;
using NullRPG.GameObjects;
using NullRPG.Managers;

namespace NullRPG.Windows.Navigation
{
    public abstract class BaseKeybindingsWindow : Console, IUserInterface
    {
        public Console Console => this;
        public IndexedKeybindings IndexedKeybindings { get; private set; }

        public BaseKeybindingsWindow(int width, int height) : base(width, height)
        {

        }

        public void Update()
        {

        }

        public T GetDrawableKeybindingObject<T>(T drawableKeybinding) where T : IDrawableKeybinding
        {
            Type type = drawableKeybinding.GetType();

            if (type == typeof(IItem))
            {
                return (T)ItemManager.GetItem<IItem>(drawableKeybinding.ObjectId);
            }
            else if (type == typeof(ILocation))
            {
                return (T)LocationManager.GetLocationByObjectId<ILocation>(drawableKeybinding.ObjectId);
            }

            return default;
        }

        public T[] GetDrawableKeybindingsObjects<T>(IDrawableKeybinding[] drawableKeybindings) where T : IDrawableKeybinding
        {
            T[] collection = new T[drawableKeybindings.Length];

            for(int i = 0; i < collection.Length; i++)
            {
                collection[i] = (T)GetDrawableKeybindingObject(drawableKeybindings[i]);
            }
            return collection;
        }
    }
}

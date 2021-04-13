using Microsoft.Xna.Framework;
using NullRPG.GameObjects.Components.Item;
using NullRPG.Input;
using NullRPG.Interfaces;
using NullRPG.Managers;
using SadConsole;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using NullRPG.Extensions;

namespace NullRPG.Draw
{
    public class PrintContainerTravel : PrintContainerBase
    {
        public PrintContainerTravel(IWorld world, IIndexedKeybinding[] keybindings) : base(keybindings)
        {
            CreateTravel(world, keybindings);
        }

        private void CreateTravel(IWorld world, IIndexedKeybinding[] keybindings)
        {
            int _index = 0;
            var areas = AreaManager.GetWorldAreas(world);

            foreach(var area in areas)
            {
                ColoredString areaName = new ColoredString(area.Name);
                PrintContainerValue areaNameValue = new PrintContainerValue(areaName, 4);

                ColoredString areaLevel = new ColoredString("areaLvl");
                PrintContainerValue areaLevelValue = new PrintContainerValue(areaLevel, 15);

                // Button
                Button = new ButtonIndex(keybindings[_index].Key, Color.Green, Color.White, 0, 0, true);
                _index++;
                Button.DrawNumericOnly(true);
                PrintContainerValue buttonValue = new PrintContainerValue(Button.GetButtonToString(), 0);

                PrintContainerItem containerItem = new PrintContainerItem(new List<PrintContainerValue>() { buttonValue, areaNameValue, areaLevelValue });
                ContainerItems.Add(containerItem);
            }
        }

        public void Draw(SadConsole.Console console, int y = 0)
        {
            int _y = y;
            foreach(var item in ContainerItems)
            {
                foreach(var value in item.ItemValues)
                {
                    console.Print(value.Offset, _y, value.ColoredString);
                }
                _y++;
            }
        }
    }
}

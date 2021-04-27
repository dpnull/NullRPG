using Microsoft.Xna.Framework;
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
    public class PrintContainerLocations : PrintContainerBase
    {
        public PrintContainerLocations(IArea area, IIndexedKeybinding[] keybindings) : base(keybindings)
        {
            CreateLocations(area, keybindings);
        }

        private void CreateLocations(IArea area, IIndexedKeybinding[] keybindings)
        {
            int _index = 0;
            var locations = Game.GameSession.Player.GetComponent<EntityComponents.Position>().Area.Locations; // refractor

            foreach(var location in locations)
            {
                ColoredString locationName = new ColoredString(location.Value.Name);
                PrintContainerValue locationNameValue = new PrintContainerValue(locationName, 4);

                ColoredString locationLevel = new ColoredString($"[ {location.Value.Level} ]");
                PrintContainerValue locationLevelValue = new PrintContainerValue(locationLevel, 19);

                // Button
                Button = new ButtonIndex(keybindings[_index].Key, Color.Green, Color.White, 0, 0, true);
                _index++;
                Button.DrawNumericOnly(true);

                PrintContainerValue buttonValue = new PrintContainerValue(Button.GetButtonToString(), 0);

                PrintContainerItem containerItem = new PrintContainerItem(new List<PrintContainerValue> { locationNameValue, locationLevelValue, buttonValue });
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

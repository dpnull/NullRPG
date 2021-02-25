using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;
using NullRPG.Extensions;
using NullRPG.Managers;
using NullRPG.GameObjects;
using SadConsole.Effects;
using NullRPG.ItemTypes;

namespace NullRPG.Windows
{
    public class ViewItemWindow : Console, IUserInterface
    {
        public Item DrawableItem { get; set; }

        public Console Console { get; set; }
        public ViewItemWindow(int width, int height) : base(width, height)
        {
            // position for character window
            Position = new Point(Constants.Windows.CharacterWidth - Constants.Windows.ViewItemWidth - 1,
                 (Constants.Windows.CharacterHeight - Constants.Windows.ViewItemHeight) / 2 + 1);

            // add only to character window and inventory window
            Global.CurrentScreen.Children.Add(this);
        }

        public override void Update(TimeSpan timeElapsed)
        {
            Clear();
            AutoHide();
            Draw();

            base.Update(timeElapsed);
        }

        private void AutoHide()
        {
            if(DrawableItem == null)
            {
                IsVisible = false;
            } else
            {
                IsVisible = true;
            }
        }

        private void Draw()
        {
            
            this.DrawBorders(Width, Height, "+", "|", "-", Color.White);
            DrawSelectedItem(DrawableItem);
        }

        private void DrawSelectedItem(Item item)
        {
            if (item != null)
            {
                // colored dmg string
                var coloredMinDmg = new ColoredString(item.MinDmg.ToString());
                coloredMinDmg.SetForeground(Color.LightGreen);
                var coloredMaxDmg = new ColoredString(item.MaxDmg.ToString());
                coloredMaxDmg.SetForeground(Color.LightGreen);
                var separator = new ColoredString(" - ");
                var dmgSuffix = new ColoredString(" Attack");
                var coloredDmg = new ColoredString("+ ");
                coloredDmg += coloredMinDmg + separator + coloredMaxDmg + dmgSuffix;

                // colored defense string
                ColoredString defense;

                if (item.Defense > 0)
                {
                    var defPrefix = new ColoredString(item.Defense.ToString());
                    defPrefix.SetForeground(Color.LightGreen);
                    var defSuffix = new ColoredString(" Defense");
                    defense = new ColoredString("+ ");
                    defense += defPrefix + defSuffix;
                }
                else if (item.Defense < 0)
                {
                    var defPrefix = new ColoredString(Math.Abs(item.Defense).ToString());
                    defPrefix.SetForeground(Color.Red);
                    var defSuffix = new ColoredString(" Defense");
                    defense = new ColoredString("+ ");
                    defense += defPrefix + defSuffix;
                }
                else
                {
                    defense = new ColoredString("\0");
                }

                // colored health string. Print empty space if value is 0 and make values red if below 0.
                ColoredString health;
                if (item.Health > 0)
                {
                    var healthPrefix = new ColoredString(item.Health.ToString());
                    healthPrefix.SetForeground(Color.LightGreen);
                    var healthSuffix = new ColoredString(" Health");
                    health = new ColoredString("+ ");
                    health += healthPrefix + healthSuffix;
                }
                else if (item.Health < 0)
                {
                    var healthPrefix = new ColoredString(Math.Abs(item.Health).ToString());
                    healthPrefix.SetForeground(Color.Red);
                    var healthSuffix = new ColoredString(" Health");
                    health = new ColoredString("- ");
                    health += healthPrefix + healthSuffix;
                }
                else
                {
                    health = new ColoredString("\0");
                }

                string value;

                if (item.Gold > 0)
                {
                    value = $"Value: {item.Gold}";
                }
                else
                {
                    value = "\0";
                }

                string name = $"- {item.Name} -";

                string level = $"ilvl {item.Level}";

                int x = 2;
                int y = 1;

                if (item is WeaponItem)
                {
                    Print(Width - level.Length - 1, y, level);
                    Print(this.GetWindowXCenter() - (name.Length / 2), y, name, Color.NavajoWhite); y++;
                    Print(x, y, coloredDmg);
                    Print(this.GetWindowXCenter() - (value.Length / 2), Height - 2, value);
                }
                else if (item is HeadItem || item is BodyItem || item is LegsItem)
                {
                    Print(Width - level.Length - 1, y, level);
                    Print(this.GetWindowXCenter() - (name.Length / 2), y, name, Color.NavajoWhite); y++;
                    Print(x, y, defense); y++;
                    Print(x, y, health);
                    Print(this.GetWindowXCenter() - (value.Length / 2), Height - 2, value);
                } else if (item is MiscItem)
                {
                    Print(Width - level.Length - 1, y, level);
                    Print(this.GetWindowXCenter() - (name.Length / 2), y, name, Color.NavajoWhite); y++;
                    Print(this.GetWindowXCenter() - (value.Length / 2), Height - 2, value);
                }
            }
          
        }

    }
}

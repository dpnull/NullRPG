using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Managers
{
    public static class CommandManager
    {
        public static void MoveUp(SadConsole.Entities.Entity entity)
        {
            entity.Position += new Microsoft.Xna.Framework.Point(0, -1);
        }

        public static void MoveDown(SadConsole.Entities.Entity entity)
        {
            entity.Position += new Microsoft.Xna.Framework.Point(0, 1);
        }

        public static void MoveLeft(SadConsole.Entities.Entity entity)
        {
            entity.Position += new Microsoft.Xna.Framework.Point(-1, 0);
        }

        public static void MoveRight(SadConsole.Entities.Entity entity)
        {
            entity.Position += new Microsoft.Xna.Framework.Point(1, 0);
        }
    }
}

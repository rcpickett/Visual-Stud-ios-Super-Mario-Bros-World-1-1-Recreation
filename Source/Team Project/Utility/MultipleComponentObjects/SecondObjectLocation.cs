using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Team_Project
{
    public static class SecondObjectLocation
    {
        public static Vector2 RightInPipe()
        {
            return (new Vector2(-32, 145));
        }

        public static Vector2 FlagPoleBlock()
        {
            return (new Vector2(-7, 152));
        }
    }
}

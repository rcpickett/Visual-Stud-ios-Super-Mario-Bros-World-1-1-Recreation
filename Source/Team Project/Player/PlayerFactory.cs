using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Team_Project
{
    public static class PlayerFactory
    {
        public static IPlayer createMario(Game1 Game)
        {
            IPlayer player = new Mario(Game.Level.PlayerStartPosition, Game);
            return player;
        }
        public static IPlayer createLuigi(Game1 Game)
        {
            IPlayer player = new Mario(Game.Level.PlayerStartPosition, Game);
            return player;
        }
    }
}

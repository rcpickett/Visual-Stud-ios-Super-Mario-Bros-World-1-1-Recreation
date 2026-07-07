using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class PlayerB : ICommand
    {
        Game1 game;

        public PlayerB(Game1 g)
        {
            game = g;
        }

        public void Execute()
        {
            game.currentPlayer.B();
        }
    }
}


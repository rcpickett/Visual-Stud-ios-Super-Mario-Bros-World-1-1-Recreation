using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class PlayerNoCommand : ICommand
    {
        Game1 game;

        public PlayerNoCommand(Game1 g)
        {
            game = g;
        }

        public void Execute()
        {
            game.currentPlayer.NoCommand();
        } 
    }
}

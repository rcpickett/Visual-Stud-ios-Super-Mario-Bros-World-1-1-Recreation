using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class Quit : ICommand
    {
        private Game1 game;

        public Quit(Game1 g)
        {
            game = g;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}

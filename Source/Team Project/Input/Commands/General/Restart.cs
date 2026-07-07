using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class Restart : ICommand
    {
        private Level level;

        public Restart(Level Level)
        {
            level = Level;
        }

        public void Execute()
        {
            level.Reset();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTypes
{
    public class Scorecard
    {
        private int numLives, points, coins;

        public int NumLives { get { return numLives; } }
        public int Points { get { return points; } }
        public int Coins { get { return coins; } }
        
        public Scorecard()
        {
            numLives = 3;
            points = 0;
            coins = 0;
        }

        public void AddLife()
        {
            numLives++;
        }

        public void LoseLife()
        {
            numLives--;
        }

        public void AddPoints(int p)
        {
            if (points != 999999) points += p;
        }

        public void AddCoin()
        {
            coins ++;
            if(coins >= 99)
            {
                coins = 0;
                numLives++;
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class LevelEndAnimation
    {
        public static Boolean MusicStopped { get; set; }
        public static Boolean Ending { get; set; }
        public static Boolean GameEnded { get; set; }
        public static Boolean MarioInCastle { get; set; }

        public static int NumFireWorks { get; set; }

        private static IProjectile firework = null;
        private static Game1 game;

        public static void LoadGame(Game1 g)
        {
            game = g;
        }

        public static void NumberOfFireworks()
        {
            NumFireWorks = game.Level.TimeRemaining;
            while (NumFireWorks > Value.Ten)
            {
                NumFireWorks -= Value.Ten;
            }

            if (NumFireWorks != Value.One && NumFireWorks != Value.Three && NumFireWorks != Value.Six)
                NumFireWorks = Value.Zero;
        }

        public static void GetFireWorkPosition(Vector2 Location)
        {

            if (NumFireWorks != Value.Zero)
            {
                SoundManager.PlayFireworksSound();
                firework = new FireWorkExplosion(Location);
            }
            else
            {
                GameEnded = true;
            }
        }

        public static void FinishedFireWork()
        {
            GameEnded = true;
            firework = null;
        }

        public static void GetFireWork(ArrayList fireballList)
        {
            if (firework != null)
            {
                fireballList.Add(firework);
            }
        }

        public static void EndingAnimationReset()
        {
            MusicStopped = false;
            Ending = false;
            GameEnded = false;
            firework = null;
            MarioInCastle = false;
        }

    }
}

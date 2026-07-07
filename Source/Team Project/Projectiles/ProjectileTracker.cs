using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class ProjectileTracker
    {
        private static int numOfFireballsOnScreen;
        private static IProjectile projectile1;
        private static IProjectile projectile2;

        public static void CreateFireball(Vector2 location, bool isFacingRight, IPlayer mario)
        {
            if (numOfFireballsOnScreen < Value.Two)
            {
                if (projectile1 == null)
                {
                    projectile1 = new Fireball(location, isFacingRight, mario);
                }
                else
                {
                    projectile2 = new Fireball(location, isFacingRight, mario);
                }
                numOfFireballsOnScreen++;
            }
        }

        public static void CreateEmber(Vector2 location, bool isFacingRight, IPlayer mario)
        {
            if (numOfFireballsOnScreen < Value.Two)
            {
                if (projectile1 == null)
                {
                    projectile1 = new BowserEmber(location, isFacingRight, mario);
                }
                else
                {
                    projectile2 = new BowserEmber(location, isFacingRight, mario);
                }
                numOfFireballsOnScreen++;
            }
        }

        public static void CreateFF(Vector2 location, bool isFacingRight, IPlayer mario)
        {
            if (numOfFireballsOnScreen < Value.Two)
            {
                if (projectile1 == null)
                {
                    if(isFacingRight)
                        projectile1 = new BowserFlamethrower(new Vector2(location.X,location.Y+5), isFacingRight, mario);
                    else
                        projectile1 = new BowserFlamethrower(new Vector2(location.X - 72, location.Y+5), isFacingRight, mario);
                }
                else
                {
                    projectile2 = new BowserFlamethrower(new Vector2(location.X-576,location.Y), isFacingRight, mario);
                }
                numOfFireballsOnScreen++;
            }
        }

        public static void CreateMF(Vector2 location, bool isFacingRight, IPlayer mario)
        {
            if (numOfFireballsOnScreen < Value.Two)
            {
                if (projectile1 == null)
                {
                    if (isFacingRight)
                        projectile1 = new BowserMegaFire(new Vector2(location.X+10,0), isFacingRight, mario);
                    else
                        projectile1 = new BowserMegaFire(new Vector2(location.X - 130, 0), isFacingRight, mario);
                }
                else
                {
                    projectile2 = new BowserFlamethrower(new Vector2(location.X - 576, location.Y), isFacingRight, mario);
                }
                numOfFireballsOnScreen++;
            }
        }

        public static void CreateIceball(Vector2 location, bool isFacingRight, IPlayer mario)
        {
            if (numOfFireballsOnScreen < Value.Two)
            {
                if (projectile1 == null)
                {
                    projectile1 = new Iceball(location, isFacingRight, mario);
                }
                else
                {
                    projectile2 = new Iceball(location, isFacingRight, mario);
                }
                numOfFireballsOnScreen++;
            }
        }

        public static void DeleteProjectile(IProjectile fireball)
        {
            if (fireball.Equals(projectile1))
            {
                projectile1 = null;
                numOfFireballsOnScreen--;
            }
            else if (fireball.Equals(projectile2))
            {
                projectile2 = null;
                numOfFireballsOnScreen--;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static int GetNumberOfProjectilesOnScreen()
        {
            return numOfFireballsOnScreen;
        }

        public static void GetFireballs(ArrayList fireballList)
        {
            if (projectile1 != null)
            {
                fireballList.Add(projectile1);
            }
            if (projectile2 != null)
            {
                fireballList.Add(projectile2);
            }
        }

        public static void ExplodeFireball(IProjectile fireball)
        {
            if (fireball.Equals(projectile1))
            {
                projectile1 = new FireballExplosion(projectile1);
            }
            if (fireball.Equals(projectile2))
            {
                projectile2 = new FireballExplosion(projectile2);
            }
        }

        public static void ExplodeIceball(IProjectile iceball)
        {
            if (iceball.Equals(projectile1))
            {
                projectile1 = new IceballExplosion(projectile1);
            }
            if (iceball.Equals(projectile2))
            {
                projectile2 = new IceballExplosion(projectile2);
            }
        }
    }
}

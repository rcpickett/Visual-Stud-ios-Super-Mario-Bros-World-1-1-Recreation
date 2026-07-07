using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class BowserMegaFire : IProjectile
    {
        private IAnimatedSprite sprite;
        private Vector2 accel = new Vector2(Speed.Zero, Speed.Zero);
        IPlayer mario;
        int timer;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }

        public BowserMegaFire(Vector2 loc, bool facingRight, IPlayer m)
        {
            Location = loc;
            if (facingRight)
                sprite = SpriteFactory.CreateRightMFSprite();
            else
                sprite = SpriteFactory.CreateLeftMFSprite();
            if (facingRight)
            {
                Movement = new Vector2(Speed.Zero, Speed.Zero);
            }
            else
            {
                Movement = new Vector2(Speed.Zero, Speed.Zero);
            }
            mario = m;
        }

        public void CollisionResponseWithEnemy(IPlayer m, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                // ProjectileTracker.ExplodeFireball(this);
                enemy.CollisionResponseWithProjectile(m, this, collision);
            }
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {

        }

        public void Update(Game1 game, GameTime gameTime)
        {
            timer++;
            sprite.Update(gameTime);
            if (timer > 200)
            {
                ProjectileTracker.DeleteProjectile(this);
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }
    }
}

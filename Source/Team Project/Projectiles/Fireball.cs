using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class Fireball : IProjectile
    {
        private IAnimatedSprite sprite;
        private Vector2 accel = new Vector2(Speed.Zero, Speed.Eight);
        IPlayer mario;

        public Vector2 Location { get; set; }
        public Vector2 Movement { get; set; }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }

        public Fireball(Vector2 loc, bool facingRight, IPlayer m)
        {
            Location = loc;
            sprite = SpriteFactory.CreateFireballSprite();
            if (facingRight)
            {
                Movement = new Vector2(Speed.Three, Speed.Three);
            }
            else
            {
                Movement = new Vector2(Speed.NegativeThree, Speed.Three);
            }
            mario = m;
        }

        public void CollisionResponseWithEnemy(IPlayer m, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                ProjectileTracker.ExplodeFireball(this);
                enemy.CollisionResponseWithProjectile(m, this, collision);
            }
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.right:
                    ProjectileTracker.ExplodeFireball(this);
                    SoundManager.PlayProjectileExplodeSound();
                    break;
                case CollisionDetector.CollisionType.left:
                    ProjectileTracker.ExplodeFireball(this);
                    SoundManager.PlayProjectileExplodeSound();
                    break;
                case CollisionDetector.CollisionType.top:
                    Location = new Vector2(Location.X, staticObject.Rectangle.Y - Rectangle.Height);
                    Movement = new Vector2(Movement.X, Speed.NegativeTwo);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    Location = new Vector2(Location.X, staticObject.Rectangle.Y + staticObject.Rectangle.Height);
                    Movement = new Vector2(Movement.X, Speed.Zero);
                    break;
            }
        }

        public void Update(Game1 game, GameTime gameTime)
        {
            float y = Movement.Y;
            y += accel.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (y > Speed.Three)
            {
                y = Speed.Three;
            }
            Movement = new Vector2(Movement.X, y);
            Location += Movement;
            sprite.Update(gameTime);
            if (Location.X < mario.Game.Camera.position.X || Location.X > mario.Game.Camera.position.X + mario.Game.Camera.viewport.Width)
            {
                ProjectileTracker.DeleteProjectile(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }
    }
}

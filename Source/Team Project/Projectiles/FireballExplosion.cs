using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class FireballExplosion : IProjectile
    {
        private IAnimatedSprite sprite;
        IProjectile fireball;

        private float timer = Value.Zero;
        private float totalTime = Value.OneHundred;

        public Vector2 Location { get { return fireball.Location; } set { fireball.Location = value; } }
        public Vector2 Movement { get { return fireball.Movement; } set { fireball.Movement = value; } }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }

        public FireballExplosion(IProjectile f)
        {
            fireball = f;
            sprite = SpriteFactory.CreateFireballExplodingSprite();
        }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
        }

        public void CollisionResponseWithStaticObject(IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
        }

        public void Update(Game1 game, GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if (timer >= totalTime)
            {
                ProjectileTracker.DeleteProjectile(this);
            }
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location, Color.White);
        }
    }
}

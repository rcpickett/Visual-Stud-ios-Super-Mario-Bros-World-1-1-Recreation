using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class IceballExplosion : IProjectile
    {
        private IAnimatedSprite sprite;
        IProjectile iceball;

        private float timer = Value.Zero;
        private float totalTime = Value.OneHundred;

        public Vector2 Location { get { return iceball.Location; } set { iceball.Location = value; } }
        public Vector2 Movement { get { return iceball.Movement; } set { iceball.Movement = value; } }
        public Rectangle Rectangle { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)sprite.TextureDimension.X, (int)sprite.TextureDimension.Y); } }

        public IceballExplosion(IProjectile f)
        {
            iceball = f;
            sprite = SpriteFactory.CreateIceballExplodingSprite();
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

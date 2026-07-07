using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class KoopaKilledState : IEnemyState
    {
        private IAnimatedSprite koopaKilledSprite;
        private Vector2 acceleration = new Vector2(Speed.Zero, Speed.One);
        private Vector2 velocity = new Vector2(Speed.Zero, Speed.NegativeEight);

        public Vector2 SpriteDimensions { get { return koopaKilledSprite.TextureDimension; } }

        public KoopaKilledState()
        {
            koopaKilledSprite = SpriteFactory.CreateKoopaKilledSprite();
        }

        public void CollisionResponseWithStaticObject(IEnemy enemy, IStaticObject staticObject, CollisionDetector.CollisionType collision){ }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, IEnemy secondEnemy, CollisionDetector.CollisionType collision){ }

        public void CollisionResponseWithPlayer(IEnemy enemy, IPlayer mario, CollisionDetector.CollisionType collision){ }

        public void CollisionResponseWithProjectile(IPlayer mario, IEnemy enemy, IProjectile projectile, CollisionDetector.CollisionType collision) { }

        public void ReverseDirection(IEnemy enemy){ }

        public void Update(GameTime gameTime)
        {
            velocity.Y += acceleration.Y;
            koopaKilledSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location.Y += velocity.Y;
            koopaKilledSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
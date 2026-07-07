using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    public class GoombaSquishedState : IEnemyState
    {
        private IAnimatedSprite goombaSquishedSprite;
        private float displayTimer;

        public Vector2 SpriteDimensions { get { return goombaSquishedSprite.TextureDimension; } }

        public GoombaSquishedState()
        {
            displayTimer = Value.Zero;
            goombaSquishedSprite = SpriteFactory.CreateGoombaSquishedSprite();
        }

        public void CollisionResponseWithStaticObject(IEnemy enemy, IStaticObject staticObject, CollisionDetector.CollisionType collision) 
        {
            if (displayTimer > Value.SevenHundredAndFifty)
            {
                enemy.Location = new Vector2(Value.NegativeOneThousand, Value.NegativeOneThousand);
            }
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    enemy.Location = new Vector2(enemy.Location.X, staticObject.Rectangle.Y - enemy.Rectangle.Height);
                    break;
            }
        }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, IEnemy secondEnemy, CollisionDetector.CollisionType collision) { }

        public void CollisionResponseWithProjectile(IPlayer mario, IEnemy enemy, IProjectile projectile, CollisionDetector.CollisionType collision) { }

        public void CollisionResponseWithPlayer(IEnemy enemy, IPlayer mario, CollisionDetector.CollisionType collision) { }

        public void ReverseDirection(IEnemy enemy) { }

        public void Update(GameTime gameTime)
        {
            displayTimer += gameTime.ElapsedGameTime.Milliseconds;
            goombaSquishedSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSquishedSprite.Draw(spriteBatch, location, Color.White);
        }

    }
}

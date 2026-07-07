using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class KoopaFrozenLeftState : IEnemyState
    {
        private IAnimatedSprite iceBlockSprite;
        private IAnimatedSprite koopaFrozenSprite;
        private Vector2 xAccel = new Vector2(1.0f, 0.0f);
        private IEnemy koopa;

        public Vector2 SpriteDimensions { get { return koopaFrozenSprite.TextureDimension; } }

        public KoopaFrozenLeftState(IEnemy k)
        {
            iceBlockSprite = SpriteFactory.CreateIceBlock1622Sprite();
            koopaFrozenSprite = SpriteFactory.CreateKoopaMovingLeftSprite();
            koopa = k;
        }

        public void CollisionResponseWithStaticObject(IEnemy enemy, IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    enemy.Location = new Vector2(enemy.Location.X, staticObject.Rectangle.Y - enemy.Rectangle.Height);
                    break;
                case CollisionDetector.CollisionType.left:
                    enemy.Location = new Vector2(staticObject.Rectangle.X - enemy.Rectangle.Width, enemy.Location.Y);
                    enemy.ReverseDirection();
                    break;
                case CollisionDetector.CollisionType.right:
                    enemy.Location = new Vector2(staticObject.Rectangle.X + staticObject.Rectangle.Width, enemy.Location.Y);
                    enemy.ReverseDirection();
                    break;
            }
        }

        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, IEnemy secondEnemy, CollisionDetector.CollisionType collision)
        {
            if (secondEnemy.GetState is KoopaShellState && secondEnemy.Movement.X != Speed.Zero)
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    enemy.KillEnemy(secondEnemy.Location);
                    mario.ScoreCard.AddPoints(enemy.PointValue);
                }
            }
            else
            {
                if (collision == CollisionDetector.CollisionType.left)
                {
                    secondEnemy.CollisionResponseWithStaticObject(new Block(enemy.Location, new FloorBlockState()), CollisionDetector.CollisionType.right);
                }
                else if (collision == CollisionDetector.CollisionType.right)
                {
                    secondEnemy.CollisionResponseWithStaticObject(new Block(enemy.Location, new FloorBlockState()), CollisionDetector.CollisionType.left);
                }
            }
        }

        public void CollisionResponseWithProjectile(IPlayer mario, IEnemy enemy, IProjectile projectile, CollisionDetector.CollisionType collision)
        {
            if (projectile is Fireball)
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    enemy.KillEnemy(projectile.Location);
                    mario.ScoreCard.AddPoints(enemy.PointValue);
                }
            }
        }

        public void CollisionResponseWithPlayer(IEnemy enemy, IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (mario is StarMario)
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    enemy.KillEnemy(mario.Location);
                    mario.ScoreCard.AddPoints(enemy.PointValue);
                }
            }
            else
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    if (collision == CollisionDetector.CollisionType.left)
                    {
                        enemy.Movement = new Vector2(Speed.One, koopa.Movement.Y);
                    }
                    else if (collision == CollisionDetector.CollisionType.right)
                    {
                        enemy.Movement = new Vector2(-Speed.One, koopa.Movement.Y);
                    }
                    mario.BlockCollision(new Block(enemy.Location, new FloorBlockState()), collision);
                }
            }
        }

        public void ReverseDirection(IEnemy enemy)
        {
        }

        public void Update(GameTime gameTime)
        {
            if (koopa.Movement.X > 0)
            {
                float x = koopa.Movement.X;
                x += -xAccel.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (x < 0)
                {
                    x = 0;
                }
                koopa.Movement = new Vector2(x, koopa.Movement.Y);
                koopa.Location += koopa.Movement;
            }
            else if (koopa.Movement.X < 0)
            {
                float x = koopa.Movement.X;
                x += xAccel.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (x > 0)
                {
                    x = 0;
                }
                koopa.Movement = new Vector2(x, koopa.Movement.Y);
                koopa.Location += koopa.Movement;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaFrozenSprite.Draw(spriteBatch, location, Color.White);
            iceBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}


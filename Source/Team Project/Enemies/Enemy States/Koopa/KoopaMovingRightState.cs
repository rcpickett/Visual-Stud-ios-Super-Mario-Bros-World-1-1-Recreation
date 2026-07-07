using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class KoopaMovingRightState : IEnemyState
    {
        private IAnimatedSprite koopaMovingRightSprite;

        public Vector2 SpriteDimensions { get { return koopaMovingRightSprite.TextureDimension; } }

        public KoopaMovingRightState()
        {
            koopaMovingRightSprite = SpriteFactory.CreateKoopaMovingRightSprite();
        }

        public void CollisionResponseWithStaticObject(IEnemy enemy, IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.left:
                    enemy.Location = new Vector2(staticObject.Rectangle.X - enemy.Rectangle.Width, enemy.Location.Y);
                    enemy.ReverseDirection();
                    break;
                case CollisionDetector.CollisionType.top:
                    enemy.Location = new Vector2(enemy.Location.X, staticObject.Rectangle.Y - enemy.Rectangle.Height);
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
                if (secondEnemy.GetState is GoombaSquishedState || secondEnemy.GetState is GoombaKilledState || secondEnemy.GetState is KoopaKilledState) { }
                else
                {
                    switch (collision)
                    {
                        case CollisionDetector.CollisionType.left:
                            enemy.Location = new Vector2(secondEnemy.Rectangle.X - enemy.Rectangle.Width, enemy.Location.Y);
                            enemy.ReverseDirection();
                            secondEnemy.Location = new Vector2(enemy.Rectangle.X + enemy.Rectangle.Width, secondEnemy.Location.Y);
                            secondEnemy.ReverseDirection();
                            break;
                        case CollisionDetector.CollisionType.right:
                            enemy.Location = new Vector2(secondEnemy.Rectangle.X + secondEnemy.Rectangle.Width, enemy.Location.Y);
                            enemy.ReverseDirection();
                            secondEnemy.Location = new Vector2(enemy.Rectangle.X - secondEnemy.Rectangle.Width, secondEnemy.Location.Y);
                            secondEnemy.ReverseDirection();
                            break;
                    }
                }
            }         
        }

        public void CollisionResponseWithProjectile(IPlayer mario, IEnemy enemy, IProjectile projectile, CollisionDetector.CollisionType collision)
        {
            if (projectile is Fireball)
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + Value.Ten);
                    enemy.KillEnemy(projectile.Location);
                    mario.ScoreCard.AddPoints(enemy.PointValue);
                }
            }
            else if (projectile is Iceball)
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    enemy.SetEnemyState(new KoopaFrozenRightState(enemy));
                    mario.ScoreCard.AddPoints(enemy.PointValue);
                }
            }
            else if (projectile is BowserEmber || projectile is BowserFlamethrower || projectile is BowserMegaFire)
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
            if (mario is StarMario || mario.Game.playerChar == Game1.Characters.Bowser)
            {
                if (collision != CollisionDetector.CollisionType.none)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + Value.Ten);
                    enemy.KillEnemy(mario.Location);
                    mario.ScoreCard.AddPoints(enemy.PointValue);
                }
            }
            else
            {
                switch (collision)
                {
                    case CollisionDetector.CollisionType.left:
                        mario.GetHit();
                        break;
                    case CollisionDetector.CollisionType.right:
                        mario.GetHit();
                        break;
                    case CollisionDetector.CollisionType.top:
                        if (mario.Movement.Y > Speed.Zero)
                        {
                            enemy.SetEnemyState(new KoopaShellState());
                            enemy.Movement = new Vector2(Speed.Zero, Speed.Zero);
                            enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + Value.Ten);
                            SoundManager.PlayEnemyStompSound();
                            if (MarioMovement.HasBounced)
                            {
                                if (enemy.PointValueIndex < 9) enemy.PointValueIndex++;
                                else
                                {
                                    enemy.PointValueIndex = 0;
                                    mario.ScoreCard.AddLife();
                                }
                            }
                            mario.ScoreCard.AddPoints(enemy.PointValue);
                            MarioMovement.Bounce();
                        }
                        break;
                    case CollisionDetector.CollisionType.bottom:
                        mario.GetHit();
                        break;
                }
            }
        }

        public void ReverseDirection(IEnemy enemy)
        {
            enemy.SetEnemyState(new KoopaMovingLeftState());
            enemy.Movement = new Vector2(enemy.Movement.X * Speed.NegativeOne, enemy.Movement.Y);
        }

        public void Update(GameTime gameTime)
        {
            koopaMovingRightSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaMovingRightSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public class KoopaShellState : IEnemyState
    {
        private IAnimatedSprite koopaShellSprite;
        private float timerToPopOutOfShell;

        public Vector2 SpriteDimensions { get { return koopaShellSprite.TextureDimension; } }

        public KoopaShellState()
        {
            koopaShellSprite = SpriteFactory.CreateKoopaShellSprite();
            timerToPopOutOfShell = Value.Zero;
        }

        public void CollisionResponseWithStaticObject(IEnemy enemy, IStaticObject staticObject, CollisionDetector.CollisionType collision)
        {
            PopOutOfShell(enemy);
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    enemy.Location = new Vector2(enemy.Location.X, staticObject.Rectangle.Y - enemy.Rectangle.Height);
                    break;
                case CollisionDetector.CollisionType.left:
                    enemy.Location = new Vector2(staticObject.Rectangle.X - enemy.Rectangle.Width, enemy.Location.Y);
                    enemy.Movement = new Vector2(enemy.Movement.X * Speed.NegativeOne, enemy.Movement.Y);
                    SoundManager.PlayBlockBumpSound();
                    break;
                case CollisionDetector.CollisionType.right:
                    enemy.Location = new Vector2(staticObject.Rectangle.X + staticObject.Rectangle.Width, enemy.Location.Y);
                    enemy.Movement = new Vector2(enemy.Movement.X * Speed.NegativeOne, enemy.Movement.Y);
                    SoundManager.PlayBlockBumpSound();
                    break;
            }
        }
        public void CollisionResponseWithEnemy(IPlayer mario, IEnemy enemy, IEnemy secondEnemy, CollisionDetector.CollisionType collision){ }
        public void CollisionResponseWithPlayer(IEnemy enemy, IPlayer mario, CollisionDetector.CollisionType collision)
        {
            if (enemy.Movement.X == Speed.Zero)
            {
                if (mario is InvincibilityFramesMario)
                {
                    if (collision == CollisionDetector.CollisionType.top && mario.Movement.Y > Speed.Zero)
                    {
                        if (mario.Location.X <= enemy.Location.X)
                        {
                            enemy.Movement = new Vector2(Speed.Three, enemy.Movement.Y);
                        }
                        else
                        {
                            enemy.Movement = new Vector2(Speed.NegativeThree, enemy.Movement.Y);
                        }
                        SoundManager.PlayEnemyKickSound();
                        mario.ScoreCard.AddPoints(enemy.PointValue);
                    }
                }
                else
                {
                    switch (collision)
                    {
                        case CollisionDetector.CollisionType.left:
                            enemy.Location = new Vector2(enemy.Location.X + Value.Five, enemy.Location.Y);
                            enemy.Movement = new Vector2(Speed.Three, enemy.Movement.Y);
                            SoundManager.PlayEnemyKickSound();
                            mario.ScoreCard.AddPoints(enemy.PointValue);
                            break;
                        case CollisionDetector.CollisionType.right:
                            enemy.Location = new Vector2(enemy.Location.X - Value.Five, enemy.Location.Y);
                            enemy.Movement = new Vector2(Speed.NegativeThree, enemy.Movement.Y);
                            SoundManager.PlayEnemyKickSound();
                            mario.ScoreCard.AddPoints(enemy.PointValue);
                            break;
                        case CollisionDetector.CollisionType.top:
                            if (mario.Location.X <= enemy.Location.X)
                            {
                                enemy.Movement = new Vector2(Speed.Three, enemy.Movement.Y);
                            }
                            else
                            {
                                enemy.Movement = new Vector2(Speed.NegativeThree, enemy.Movement.Y);
                            }
                            MarioMovement.Bounce();
                            SoundManager.PlayEnemyKickSound();
                            mario.ScoreCard.AddPoints(enemy.PointValue);
                            break;
                    }
                }
            } 
            else
            {
                if (mario is StarMario)
                {
                    if (collision != CollisionDetector.CollisionType.none)
                    {
                        enemy.KillEnemy(mario.Location);
                    }
                }
                else if (mario is InvincibilityFramesMario)
                {
                    if (collision == CollisionDetector.CollisionType.top && mario.Movement.Y > Speed.Zero)
                    {
                        enemy.Movement = new Vector2(Speed.Zero, enemy.Movement.Y);
                        MarioMovement.Bounce();
                        SoundManager.PlayEnemyKickSound();
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
                            enemy.Movement = new Vector2(Speed.Zero, enemy.Movement.Y);
                            MarioMovement.Bounce();
                            SoundManager.PlayEnemyKickSound();
                            mario.ScoreCard.AddPoints(enemy.PointValue);
                            break;
                        case CollisionDetector.CollisionType.bottom:
                            mario.GetHit();
                            break;
                    }
                }
            }    
        }
        public void CollisionResponseWithProjectile(IPlayer mario, IEnemy enemy, IProjectile projectile, CollisionDetector.CollisionType collision) 
        {
            if (collision != CollisionDetector.CollisionType.none)
            {
                enemy.KillEnemy(projectile.Location);
            }
        }
        public void ReverseDirection(IEnemy enemy)
        {
            enemy.Movement = new Vector2(enemy.Movement.X * Speed.NegativeOne, enemy.Movement.Y);
        }
        private void PopOutOfShell(IEnemy enemy)
        {
            if (timerToPopOutOfShell > Value.FiveThousand && enemy.Movement.X == Speed.Zero)
            {
                enemy.SetEnemyState(new KoopaMovingLeftState());
                enemy.Movement = new Vector2(Speed.NegativeOneHalf, Speed.Zero);
            }
            else if (enemy.Movement.X != Speed.Zero)
            {
                timerToPopOutOfShell = Value.Zero;
            }
        }
        public void Update(GameTime gameTime)
        {
            timerToPopOutOfShell += gameTime.ElapsedGameTime.Milliseconds;
            koopaShellSprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            koopaShellSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}